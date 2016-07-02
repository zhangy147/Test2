using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;  //for HttpStatusCodeResult
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Data;
using System.Data.Entity;

using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;


namespace WebTest.Controllers
{
    public class MedicalHistoryController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        
        [HttpGet]
        public ActionResult BuildMedicalHistory()
        {
            int currentPatientProfileId = GetCurrentPatientProfileID();
            MedicalHistoryViewData smvd = new MedicalHistoryViewData();
            //
            //smvd.CurrentPatientProfile = GetCurrentPatientProfile();
            //
            smvd.AvailablePatientProfiles = MedicalHistoryManager.Instance.GetAvailablePatientProfiles();


            smvd.DiseaseHistories = MedicalHistoryManager.Instance.GetPatientDiseaseHistoryViewData(currentPatientProfileId);
            smvd.SurgicalHistories = MedicalHistoryManager.Instance.GetPatientSurgicalHistoryViewData(currentPatientProfileId);
            smvd.SystemReviews = MedicalHistoryManager.Instance.GetPatientSystemReviewViewData(currentPatientProfileId);
            //smvd.MedicalRecords = GetRequiredRecords(smvd.CurrentPatientProfile);
            smvd.FamilyHistories = MedicalHistoryManager.Instance.GetPatientFamilyHistoryViewData(currentPatientProfileId);
            //smvd.SocialHistory = MedicalHistoryManager.Instance.GetPatientSocialHistory(currentPatientProfileId);
            //

            //return View(smvd);
            return PartialView("MedicalHistoryPanel", smvd);
        }

        //============================================================================
        //  Past Medical Condtion and Suegry History
        //============================================================================
        [HttpGet]
        public ActionResult GetMedicalConditionHistory()
        {            
            int currentPatientProfileId = 2;
            List<PatientMedicalConditionHistoryViewData> medicalConditionHistories = MedicalHistoryManager.Instance.GetPatientMedicalConditionHistoryViewData(currentPatientProfileId);
            //
            return PartialView("_MedicalConditionHistoryTab", medicalConditionHistories);
        }

        [HttpPost]
        public ActionResult SaveMedicalConditionHistory([Bind]PatientMedicationAndAllergyHistoryViewData mah, string nextPage)
        {
            if (mah != null) { }

            return RedirectToNextPage(nextPage);
            //return RedirectToAction("GetMedicalConditionHistory");
        }

        /// <summary>
        /// Get and Save DiseaseHistory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDiseaseHistory()
        {
            //logger.Debug("GetDiseaseHistory()");
            int currentPatientProfileId = GetCurrentPatientProfileID();
            //logger.Debug("currentPatientProfileId=" + currentPatientProfileId);
            List<PatientDiseaseHistoryViewData> diseaseHx = MedicalHistoryManager.Instance.GetPatientDiseaseHistoryViewData(currentPatientProfileId);
            //logger.Debug("count of diseaseHx=" + diseaseHx.Count());
            return PartialView("_DiseaseHistoryTab", diseaseHx);
        }

        [HttpPost]
        public ActionResult SaveDiseaseHistory(List<PatientDiseaseHistoryViewData> diseaseHistories, string PageModified, string PageRequested)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //logger.Debug("size of input diseaseHistories:" + diseaseHistories.Count);
                    //foreach (var d in diseaseHistories)
                    //{
                    //   logger.Debug("Disease is saved with DiseaseID=" + d.DiseaseID);
                    //}
                    return RedirectToAction("GetSystemReview");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
             return PartialView("_DiseaseHistoryTab", diseaseHistories);
        }

 
        /// <summary>
        /// Get and Save SystemReview
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSystemReview()
        {
            int currentPatientProfileId = GetCurrentPatientProfileID();
            List<SystemReviewViewData> systemReviewVD = MedicalHistoryManager.Instance.GetPatientSystemReviewViewData(currentPatientProfileId);
            //logger.Debug("systemReviewVD=" + systemReviewVD.Count());
            return PartialView("_SystemReviewTab", systemReviewVD);
        }

        [HttpPost]
        public ActionResult SaveSystemReview(List<SystemReviewViewData> systemReviews, string nextPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("SaveSystemReview=" + systemReviews.Count());
                    //return PartialView("_SystemReviewTab", systemReviews);
                    return RedirectToNextPage(nextPage);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
            return PartialView("_SystemReviewTab", systemReviews);
        }
        /// <summary>
        /// Get and Save FamilHistory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFamilyHistory()
        {
            //logger.Debug("GetFamilyHistory Called");
            int currentPatientProfileId = GetCurrentPatientProfileID();
            //logger.Debug("currentPatientProfileId=" + currentPatientProfileId);
            PatientFamilyDiseaseHistoryViewData familyDiseaseHxVD = MedicalHistoryManager.Instance.GetPatientFamilyHistoryViewData(currentPatientProfileId);
            
            //logger.Debug("familyDiseaseHxVD=" + familyDiseaseHxVD.FamilyMembers.Count());
            return PartialView("_FamilyHistoryTab", familyDiseaseHxVD);
        }

        [HttpPost]
        public ActionResult SaveFamilyHistory(PatientFamilyDiseaseHistoryViewData familyHistory, string nextPage)
        {
            logger.Debug("SaveFamilyHistory");
            familyHistory.FamilyMembers = Enum.GetValues(typeof(FamilyMember)).Cast<FamilyMember>().Select(v => v).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("size of input family history:" + familyHistory.FamilyDiseaseHistories.Count);
                    //foreach (var d in diseaseHistories)
                    //{
                    //   logger.Debug("Disease is saved with DiseaseID=" + d.DiseaseID);
                    //}
                    return RedirectToNextPage(nextPage);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
            return PartialView("_FamilyHistoryTab", familyHistory);
        }
        /// <summary>
        /// Get and Save SocialHistory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSocialHistory()
        {
            int currentPatientProfileId = GetCurrentPatientProfileID();
            PopulateSocialHistoryViewBags();
            PatientSocialHistoryViewData socialHxVD = MedicalHistoryManager.Instance.GetPatientSocialHistoryViewData(currentPatientProfileId);
            return PartialView("_SocialHistoryTab", socialHxVD);
        }

        [HttpPost]
        public ActionResult SaveSocialHistory(PatientSocialHistoryViewData socialHistory, string nextPage)
        {
            logger.Debug("SaveSocialHistory is called");
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("Marital status in socialHistory:" + socialHistory.MaritalStatus.ToString());
                    //logger.Debug("size of input SubstanceUse:" + socialHistory.SubstanceUses.Count);
                    //foreach (var d in socialHistory.SubstanceUses)
                    //{
                    //   logger.Debug("Substance name=" + d.Substance.ToString());
                    //}
                    //return RedirectToAction("GetRequiredMedicalRecords", "MedicalRecord");
                    return RedirectToNextPage(nextPage);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
            PopulateSocialHistoryViewBags();
            return PartialView("_SocialHistoryTab", socialHistory);
        }
        //
        public void PopulateSocialHistoryViewBags()
        {
            //IEnumerable<Substance> substances = Enum.GetValues(typeof(Substance)).Cast<Substance>();
            //IEnumerable<MaritalStatus> maritalStatuses = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>();
            //ViewBag.SubstanceList = from s in substances
            //                        select new SelectListItem
            //                        {
            //                            Text = s.ToString(),
            //                            Value = ((int)s).ToString()
            //                        };
           ViewBag.SubstanceList = Enum.GetValues(typeof(Substance)).Cast<Substance>().ToList();
            ViewBag.MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().ToList();
            //ViewBag.MaritalStatusList = from m in maritalStatuses
            //                            select new SelectListItem
            //                            {
            //                                Text = m.ToString(),
            //                                Value = ((int)m).ToString()
            //                            };
            ViewBag.EmploymentStatusList = Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>().ToList();
            ViewBag.ExerciseLevelList = Enum.GetValues(typeof(ExerciseLevel)).Cast<ExerciseLevel>().ToList();
        }
        //
        //==============================================================================
        //  Medication and Allergy History
        //==============================================================================
        [HttpGet]
        public ActionResult GetMedicationAndAllergyHistory()
        {
            int currentPatientProfileId = 2;
            //
            logger.Debug("GetMedicationAndAllergyHistory is called");
            //
            List<PatientMedicationHistory> medicationHxs = MedicalHistoryManager.Instance.GetPatientMedicationHistories(currentPatientProfileId);
            List<PatientMedicationHistoryViewData> medicationHxsVD = new List<PatientMedicationHistoryViewData>();
            if (medicationHxs != null)
            {
                foreach (var a in medicationHxs)
                {
                    medicationHxsVD.Add(new PatientMedicationHistoryViewData()
                    {
                        DrugName = a.DrugName,
                        Dose = a.Dose,
                        HowOften = a.HowOftenTaken,
                        HowLong = a.HowLongTakenInMonth
                    });
                }
            }
            //
            currentPatientProfileId = 2;
            List<PatientAllergyHistory> allergyHxs = MedicalHistoryManager.Instance.GetPatientAllergyHistories(currentPatientProfileId);
            List<PatientAllergyHistoryViewData> allergyHxsVD = new List<PatientAllergyHistoryViewData>();
            if (allergyHxs != null)
            {
                foreach (var b in allergyHxs)
                {
                    allergyHxsVD.Add(new PatientAllergyHistoryViewData()
                    {
                        AntigenName = b.AntigenName,
                        IsMedicine = b.IsMedicine,
                        Reaction = b.Reaction,
                        YearDiscovered = b.YearDiscovered
                    });

                }
            }
            //allergyHxsVD.Add(new PatientAllergyHistoryViewData());
            //
            PatientMedicationAndAllergyHistoryViewData mah = new PatientMedicationAndAllergyHistoryViewData();
            mah.medicationHistories = medicationHxsVD;
            if (medicationHxsVD.Count > 0)
            {
                mah.HasMedicationHistory = true;
            }
            mah.allergyHistories = allergyHxsVD;
            if (allergyHxsVD.Count > 0)
            {
                mah.HasAllergyHistory = true;
            }
            logger.Debug("GetMedicationAndAllergyHistory is returned");
            return PartialView("_MedicationAndAllergyHistoryTab", mah);
        }
        [HttpGet]
        public ActionResult AddMedicationHistory()
        {
            return PartialView("_MedicationHistory", new List<PatientMedicationHistoryViewData>() { new PatientMedicationHistoryViewData() });
        }
        [HttpGet]
        public ActionResult AddAllergyHistory()
        {
            return PartialView("_AllergyHistory", new List<PatientAllergyHistoryViewData>() { new PatientAllergyHistoryViewData() });
        }
        [HttpPost]
        public ActionResult SaveMedicationAndAllergyHistory([Bind]PatientMedicationAndAllergyHistoryViewData mah, string nextPage)
        {
            if (mah != null)
            {
                logger.Debug("PatientMedicationAndAllergyHistoryViewData is not null");
                logger.Debug("No medication history: " + mah.HasMedicationHistory);
                if (mah.medicationHistories != null)
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
                if (mah.allergyHistories != null)
                {
                    foreach (var a in mah.allergyHistories)
                    {
                        logger.Debug("Allergen Name: " + a.AntigenName);
                    }
                }
                else
                {
                    logger.Debug("Allergy history is null ");
                }
                return RedirectToNextPage(nextPage);
            }
            else
            {
                logger.Debug("Medication history is null ");
            }
            return PartialView("_MedicationAndAllergyHistoryTab", mah);
        }
    }
}
