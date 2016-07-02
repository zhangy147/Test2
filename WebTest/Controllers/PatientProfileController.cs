using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Net; //HttpStatusCode
//
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;

namespace WebTest.Controllers
{
    public class PatientProfileController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index(int step = 1)
        {
            int userID = 1;
            int profileId = GetCurrentPatientProfileID();
            int diseaseId = GetCurrentDiseaseID();

            ViewBag.ProfileCreated = false;

            ServiceOrder userOrder = null;
            if (profileId > 0 && diseaseId > 0)
            {
                userOrder = db.ServiceOrders
                .Where(s => s.UserID == userID)
                .Where(d => d.PatientProfileID == profileId)
                .Where(s => s.DiseaseID == diseaseId)
                .SingleOrDefault();

                ViewBag.ProfileCreated = true;
            }

            ViewBag.UserRequest = userOrder;       

            //ViewBag.ActiveStep = step;
      

            return View();
        }
        [HttpGet]
        public ActionResult GetPage(int TargetStep, int TargetTab)
        {
            //logger.Debug("targetStep=" + TargetStep + " and targetTab=" + TargetTab);
            switch(TargetStep){
                case 0:
                    if (TargetTab == 0)
                    {
                        return RedirectToAction("GetDiseaseInformation", "PatientProfile");
                    }
                    else if (TargetTab == 1)
                    {
                        return RedirectToAction("GetPatientInformation", "PatientProfile");
                    }
                    break;
                case 1:
                    if (TargetTab == 0) 
                    {
                        return RedirectToAction("GetDiseaseProcedures", "DiseaseState");
                    }
                    else if (TargetTab == 1)
                    {
                        return RedirectToAction("GetInitialTreatmentFactors", "DiseaseState");
                    }
                    else if (TargetTab == 2)
                    {
                        return RedirectToAction("GetTreatmentFactorsII", "DiseaseState");
                    }
                    else if (TargetTab == 3)
                    {
                        return RedirectToAction("GetTreatmentFactorsIII", "DiseaseState");
                    }
                    break;
                case 2:
                    if (TargetTab == 0)
                    {
                        //return RedirectToAction("GetDiseaseHistory", "MedicalHistory");
                        return RedirectToAction("GetMedicalConditionHistory", "MedicalHistory");
                    }
                    else if (TargetTab == 1)
                    {
                        //return RedirectToAction("GetSystemReview", "MedicalHistory");
                        return RedirectToAction("GetMedicationAndAllergyHistory", "MedicalHistory");
                    }
                    else if (TargetTab == 2)
                    {
                        return RedirectToAction("GetFamilyHistory", "MedicalHistory");
                    }
                    else if (TargetTab == 3)
                    {
                        return RedirectToAction("GetSocialHistory", "MedicalHistory");
                    }
                    break;
                case 3:
                    if (TargetTab == 0)
                    {
                        return RedirectToAction("GetRequiredMedicalRecords", "MedicalRecord");
                    }
                    else if (TargetTab == 1)
                    {
                        return RedirectToAction("ShowUploadMedicalRecord", "MedicalRecord");
                    }
                    else if (TargetTab == 2)
                    {
                        return RedirectToAction("GetUploadedMedicalRecords", "MedicalRecord");
                    }
                    break;
                case 4:
                    if (TargetTab == 0)
                    {
                        return RedirectToAction("GetServiceSummary", "Service");
                    }
                    else if (TargetTab == 1)
                    {
                        return RedirectToAction("CollectPayment", "Service");
                    }
                    break;
            }
            return PartialView("_Error");
           
        }

        //[HttpGet]
        //public ActionResult BuildPatientProfile()
        //{
        //    return PartialView("_PatientProfilePanel");
        //}

        public PatientProfile GetPatientProfile(int profileId)
        {
            if (profileId > 0)
            {
                PatientProfile currProfile = db.PatientProfiles
                .Where(d => d.PatientProfileID == profileId)
                .Single();
                //
                //currProfile.ReceivedProcedures = db.PatientReceivedProcedures
                //   .Where(s => s.PatientProfileID == currProfile.PatientProfileID)
                //   .ToList();
                ////
                //currProfile.TreatmentConditions = db.PatientTreatmentConditions
                //    .Where(s => s.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                ////
                //currProfile.DiseaseHistories = db.PatientDiseaseHistories
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                //currProfile.SurgicalHistories = db.PatientSurgicalHistories
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                //currProfile.SystemReviews = db.PatientSystemReviews
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                //currProfile.SocialHistory = db.PatientSocialHistories
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .SingleOrDefault();
                //currProfile.FamilyDiseaseHistories = db.PatientFamilyDiseaseHistories
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                ////
                //currProfile.MedicalRecords = db.PatientMedicalRecords
                //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
                //    .ToList();
                return currProfile;
            }
            return null;
        }
        //
        [HttpGet]
        public JsonResult GetDiseaseNameList(string term)
        {
            HttpCookie nCulture = Request.Cookies["_culture"];
            if (nCulture != null && nCulture.Value == "zh")
            {
                var diseasesBySystem = from s in db.Diseases
                                       where s.CName.Contains(term)
                                       select new
                                       {
                                           id = s.DiseaseID,
                                           value = s.CName,
                                           label = s.CName
                                       };
                return Json(diseasesBySystem.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var diseasesBySystem = from s in db.Diseases
                                   where s.Name.Contains(term)
                                   select new
                                   {
                                       id = s.DiseaseID,
                                       value = s.Name,
                                       label = s.Name
                                   };
                return Json(diseasesBySystem.ToList(), JsonRequestBehavior.AllowGet);
            }
            
        }
        //
        //=============================================================
        // Patient Profile 
        //=============================================================
        [HttpGet]
        public ActionResult GetDiseaseInformation()
        {
            HttpCookie nCulture = Request.Cookies["_culture"];
            
            DiseaseViewData diseaseViewData = new DiseaseViewData();
            int patientProfileId = GetCurrentPatientProfileID();
            int diseaseId = GetCurrentDiseaseID();
            if (patientProfileId > 0)
            {
                PatientProfile pProfile = GetPatientProfile(patientProfileId);
                Disease disease = db.Diseases
                    .Where(s => s.DiseaseID == diseaseId)
                    .SingleOrDefault();
                diseaseViewData.DiseaseID = diseaseId;
                if (nCulture != null && nCulture.Value == "zh")
                {
                    diseaseViewData.DiseaseName = disease.CName;
                }
                else
                {
                    diseaseViewData.DiseaseName = disease.Name;
                }
                diseaseViewData.DateDiagnosed = pProfile.DateDiagnosed;
            }
            return PartialView("_DiseaseTab", diseaseViewData);
        }

        [HttpPost]
        public ActionResult SaveDiseaseInformation(DiseaseViewData disease, string nextPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("DiseaseID=" + disease.DiseaseID);
                    logger.Debug("DateDiagnosed=" + disease.DateDiagnosed);
                    //
                    SharedSession["DiseaseID"] = 4;
                    //
                    return RedirectToNextPage(nextPage);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again later (" + dex + ")");
            }
            return PartialView("_DiseaseTab", disease);

        }

        [HttpGet]
        public ActionResult GetPatientInformation()
        {
            logger.Debug("GetPatientInformation() is called");
            PatientViewData patientViewData = new PatientViewData();
            int pProfileId = GetCurrentPatientProfileID();
            var patientProfile = GetPatientProfile(pProfileId);
            if (patientProfile != null)
            {
                patientViewData.Age = patientProfile.Age;
                patientViewData.Gender = patientProfile.Gender;
                patientViewData.Ethnic = patientProfile.Ethnic;
                patientViewData.Concerns = patientProfile.Concerns;
            }
            logger.Debug("return partial view of _PatientTab");
            return PartialView("_PatientTab", patientViewData);
        }
        [HttpPost]
        public ActionResult SavePatientInformation(PatientViewData patient, string nextPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("Patient Age=" + patient.Age);
                    logger.Debug("Patient Sex=" + patient.Gender);
                    logger.Debug("Patient Ethnic=" + patient.Ethnic);
                    logger.Debug("Patient Concerns=" + patient.Concerns);
                    //
                    //Session["PatientProfileID"] = 2;
                    SharedSession["PatientProfileID"] = 2;
                    logger.Debug("PatientProfileID in session is:" + SharedSession["PatientProfileID"]);
                    //
                    //return RedirectToAction("GetDiseaseProcedures", "DiseaseState");
                    return RedirectToNextPage(nextPage);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again (" + dex + ")");
                
            }
            return PartialView("_PatientTab", patient);
           
            //return Json(new { Valid = ModelState.IsValid, Errors = GetErrorsFromModelState() });
        }

        //EXPERIMENTAL 
        public class ValidateAjaxAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!filterContext.HttpContext.Request.IsAjaxRequest())
                    return;

                var modelState = filterContext.Controller.ViewData.ModelState;
                if (!modelState.IsValid)
                {
                    var errorModel =
                            from x in modelState.Keys
                            where modelState[x].Errors.Count > 0
                            select new
                            {
                                key = x,
                                errors = modelState[x].Errors.
                                                       Select(y => y.ErrorMessage).
                                                       ToArray()
                            };
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.Result = new JsonResult()
                    {
                        Data = errorModel
                    };
                    
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
        }
    }
}