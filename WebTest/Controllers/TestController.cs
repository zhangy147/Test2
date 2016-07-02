using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
//
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.Managers;

namespace WebTest.Controllers
{
    public class TestController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ProcessStep()
        {
            return View();
        }
        public ActionResult AutoCompleteDiseaseName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutoCompleteDiseaseName([Bind(Include = "DiseaseID, DiseaseName")]PatientProfileDiseaseViewData ppdv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);

            }
            return View();
        }

        [HttpGet]
        public ActionResult NavigateTabs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AjaxUploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadMedicalRecord(HttpPostedFileBase FileInput)
        {
            string error = "";
            logger.Debug("UploadMedicalRecord");
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("ModelState.IsValid");

                    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
                    string fileName = "";
                    string fileType = "";
                    //HttpPostedFileBase file = uploadedRecord.File;
                    HttpPostedFileBase file = FileInput;

                    if (file != null)
                    {
                        logger.Debug("file is not null");
                        fileName = System.IO.Path.GetFileName(file.FileName);
                        fileType = System.IO.Path.GetExtension(file.FileName).Substring(1);

                        logger.Debug("fileName=" + fileName);
                        logger.Debug("fileType=" + fileType);
                        ////db.SaveChanges();
                        //
                        return PartialView("_UploadSuccessful");
                    }
                    else
                    {
                        error = "uploadedRecord.File is null";
                        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, error);
                    }
                }
                else
                {
                    error = "ModelState is invalid, details =";
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
                error = "RetryLimitExceededException";

            }
            catch (Exception something)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + something);
                error = "Exception";
            }
            logger.Debug("uploadedRecord, error=" + error);
            //return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, error);
            //return PartialView("_UploadMedicalRecordTab", uploadedRecord);
            return PartialView("_UploadFailed");
        }

        [HttpGet]
        public ActionResult GetMedicationHistory()
        {
            int currentPatientProfileId = 2;

            //PopulateSocialHistoryViewBags();
            //List<PatientMedicationHistory> medicationHxs = MedicalHistoryManager.Instance.GetPatientMedicationHistories(currentPatientProfileId);
            //if(medicationHxs == null){
            List<PatientMedicationHistoryViewData> medicationHxs = new List<PatientMedicationHistoryViewData>();
            medicationHxs.Add(new PatientMedicationHistoryViewData());
            medicationHxs.Add(new PatientMedicationHistoryViewData());
            //
            List<PatientAllergyHistoryViewData> allergyHx = new List<PatientAllergyHistoryViewData>();
            allergyHx.Add(new PatientAllergyHistoryViewData());
            //
            PatientMedicationAndAllergyHistoryViewData mah = new PatientMedicationAndAllergyHistoryViewData();
            mah.medicationHistories = medicationHxs;
            mah.allergyHistories = allergyHx;
            //}

            return PartialView("MedicationHx", mah);
        }
        [HttpGet]
        public ActionResult AddMedicationHistory()
        {
            return PartialView("_MedicationHistory", new List<PatientMedicationHistoryViewData>() { new PatientMedicationHistoryViewData() });
        }
        [HttpGet]
        public ActionResult AddAllergyHistory()
        {
            return PartialView("_AllergyHistory", new List<PatientAllergyHistoryViewData>() { new PatientAllergyHistoryViewData()});
        }
        [HttpPost]
        public ActionResult SaveMedicationAndAllergyHistory([Bind]PatientMedicationAndAllergyHistoryViewData mah)
        {
            if(mah != null){
                logger.Debug("PatientMedicationAndAllergyHistoryViewData is not null");
                logger.Debug("Title: " + mah.HasMedicationHistory);

                if(mah.medicationHistories != null)
                {
                    foreach (var s in mah.medicationHistories)
                    {
                        logger.Debug("Drug Name: " + s.DrugName);
                    }
                }
                else
                {
                    logger.Debug("Medication history is null ");
                }
                //if (mah.allergyHistories != null)
                //{
                //    foreach (var a in mah.allergyHistories)
                //    {
                //        logger.Debug("Allergen Name: " + a.AntigenName);
                //    }
                //}
                //else
                //{
                //    logger.Debug("Allergy history is null ");
                //}

            }
            else
            {
                logger.Debug("Medication history is null ");
            }
            return RedirectToAction("GetMedicationHistory");
        }
        //
        //
        [HttpGet]
        public ActionResult GetMedicalConditionHx()
        {
            int currentPatientProfileId = 2;
            List<PatientMedicalConditionHistoryViewData> medicalConditionHistories = MedicalHistoryManager.Instance.GetPatientMedicalConditionHistoryViewData(currentPatientProfileId);
            //if(medicationHxs == null){
            int systemTotal = medicalConditionHistories.Count();
            logger.Debug("systemTotal=" + systemTotal.ToString());
            int columns = 3;
            double blok =(double)5/(double)3;
            logger.Debug("blok=" + blok.ToString());
            int sectionCount = (int)Math.Ceiling(blok);
            logger.Debug("sectionCount=" + System.Convert.ToString(sectionCount));

            return View("MedicalConditionHx", medicalConditionHistories);
        }
    }
}


