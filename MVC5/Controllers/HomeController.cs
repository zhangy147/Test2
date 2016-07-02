using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult MoreSecondOpinion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EnterSecondOpinion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MoreLiveConsulting()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EnterLiveConsulting()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MoreTreatmentReport()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EnterTreatmentReport()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MoreTreatmentInUSA()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EnterTreatmentInUSA()
        {
            return View();
        }
        [HttpGet]
        public ActionResult USAOnlineMedicalResources()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EvidenceBasedMedicine()
        {
            return View();
        }
        [HttpGet]
        public ActionResult USAHospitalIntroduction()
        {
            return View();
        }
    }
}