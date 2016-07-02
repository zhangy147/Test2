using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Helpers;

namespace WebTest.Controllers
{
    public class SiteController : BaseController
    {
        public ActionResult SetCulture(string culture, string returnUrl)
        {
            culture = CultureHelper.GetImplementedCulture(culture);
       
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture; 
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            //
            string decodedUrl = "";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                decodedUrl = Server.UrlDecode(returnUrl);
            }
            if (Url.IsLocalUrl(decodedUrl) && decodedUrl.Length > 1)
            {
                return Redirect(decodedUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
	}
}