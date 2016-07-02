using System;
using System.Web;
using System.Web.Mvc;
using System.Threading;
//
using System.IO;
using System.Collections.Generic;
//
using WebTest.Helpers;

namespace WebTest.Controllers
{
    public class BaseController : Controller
    {
        private HttpSessionStateBase _session;
        //private HttpRequestBase _cookie;

        protected HttpSessionStateBase SharedSession
        {
            get
            {
                if (_session == null)
                {
                    _session = Session;
                }
                return _session;
            }
            set
            {
                _session = Session;
            }
        }

        public int GetCurrentPatientProfileID()
        {
            if (SharedSession["PatientProfileID"] != null)
            {
                return (int)SharedSession["PatientProfileID"];
            }
            return 0;
        }
        public int GetCurrentDiseaseID()
        {
            if (SharedSession["DiseaseID"] != null)
            {
                return (int)SharedSession["DiseaseID"];
            }
            return 0;
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                Request.UserLanguages[0] : // obtain it from HTTP header AcceptLanguages
                null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is  safe
            // Modify current thread's cultures 
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }

        public string RenderPartialViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult =
                    ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext,
                    viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        // This method helps to get the error information from the MVC "ModelState".
        // We can not directly send the ModelState to the client in Json. The "ModelState"
        // object has some circular reference that prevents it to be serialized to Json.
        public Dictionary<string, object> GetErrorsFromModelState()
        {
            var errors = new Dictionary<string, object>();
            foreach (var key in ModelState.Keys)
            {
                // Only send the errors to the client.
                if (ModelState[key].Errors.Count > 0)
                {
                    errors[key] = ModelState[key].Errors;
                }
            }

            return errors;
        }
        //
        public ActionResult RedirectToNextPage(string nextPage)
        {
            char[] delimiterChars = { '-' };
            string[] targets = nextPage.Split(delimiterChars);
            int tStep = Int32.Parse(targets[0]);
            int tTab = Int32.Parse(targets[1]);
            //
            return RedirectToAction("GetPage", "PatientProfile", new { TargetStep = tStep, TargetTab = tTab });
        }
    }
}