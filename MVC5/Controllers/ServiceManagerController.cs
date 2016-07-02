using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;  //for HttpStatusCodeResult
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Data;
using System.Data.Entity;

using MVC5.Models;
using MVC5.ViewModels;
using MVC5.DatabaseContexts;
using MVC5.Helpers;

namespace MVC5.Controllers
{
    public class ServiceManagerController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index(int? serviceId)
        {

            if (serviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceManagerViewData smvd = new ServiceManagerViewData();
            //smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();

            //smvd.RequestedServices = GetRequestedServices(currPatientProfile);
            smvd.AvailableProviders = GetServiceProviderSelectList(null);
            smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();

            //
            PatientProfile cpp = getCurrentPatientProfile();
            //
            //customize the current petient profile
            cpp.RequestedServices = new List<RequestedService>();
            cpp.PatientProfileID = 1;
            cpp.DiseaseID = 14;
            cpp.Disease = db.Diseases.Find(cpp.DiseaseID);
            //
            smvd.SocialHistory = GetSocialHistoryViewData(cpp.PatientProfileID);
            //
            smvd.CurrentPatientProfile = cpp;
            //
            logger.Error("This is a test for log4net app");
            //
            return View(smvd);
        }

        [HttpGet]
        public ActionResult Thumbnail()
        {

            ImageViewData ivd = new ImageViewData();
            ivd.Width = 50;
            ivd.Height = 50;
            ivd.FileName = "mri_example.jpg";

            return View(ivd);
        }

        [HttpGet]
        public ThumbnailActionResult GetThumbnail(string imageName, int width, int height)
        {
            ThumbnailController th = new ThumbnailController();
            return th.Generate(width, height, imageName);
        }

        //
        [HttpGet]
        public ActionResult MotherBoard(string error)
        {
            if (error != "")
            {
                ViewBag.Error = error;
            }
            ServiceManagerViewData smvd = new ServiceManagerViewData();
            //
            smvd.CurrentPatientProfile = getCurrentPatientProfile();
            //
            smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();
            smvd.PatientQuerstions = GetPatientPostedQuestions(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.RequestedServices = GetRequestedServices(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.MedicalHistories = GetPatientMedicalHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SurgicalHistories = GetPatientSurgicalHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SystemReviews = GetPatientSystemReviewViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.MedicalRecords = GetRequiredRecords(smvd.CurrentPatientProfile);
            smvd.FamilyHistories = GetFamilyHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SocialHistory = GetSocialHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            //

            return View(smvd);
        }

        //
        [HttpGet]
        public ActionResult BuildMedicalHistory(string error)
        {
            if (error != "")
            {
                ViewBag.Error = error;
            }
            ServiceManagerViewData smvd = new ServiceManagerViewData();
            //
            smvd.CurrentPatientProfile = getCurrentPatientProfile();
            //
            smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();
            smvd.PatientQuerstions = GetPatientPostedQuestions(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.RequestedServices = GetRequestedServices(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.MedicalHistories = GetPatientMedicalHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SurgicalHistories = GetPatientSurgicalHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SystemReviews = GetPatientSystemReviewViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.MedicalRecords = GetRequiredRecords(smvd.CurrentPatientProfile);
            smvd.FamilyHistories = GetFamilyHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            smvd.SocialHistory = GetSocialHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
            //

            return View(smvd);
        }


        //
        // POST: /UserService/Create




        //
        // POST: /UserService/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SignPrivacyPolicy(string requestedService)
        {
            ViewBag.Service = requestedService;
            return View();
        }
        [HttpPost]
        public ActionResult SignPrivacyPolicy(string requestedService, string id)
        {
            if (string.Compare(requestedService, "SecondOpinion", true) == 0)
            {
                return RedirectToAction("EnterSecondOpinion", "SecondOpinion");
            }
            else if (string.Compare(requestedService, "LiveConsulting", true) == 0)
            {
                return RedirectToAction("EnterLiveConsulting", "LiveConsulting");
            }



            else if (string.Compare(requestedService, "TreatmentReport", true) == 0)
            {
                return RedirectToAction("EnterTreatmentReport", "TreatmentReport");
            }
            else
                return View();

        }
        [HttpGet]
        public ActionResult RequestService(int? serviceId)
        {
            if (serviceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*
             * Declare a RequestedService object and pass it into View
             */
            RequestedService rs = new RequestedService();
            rs.ServiceID = 3;
            rs.PatientProfileID = 1;
            /*
             * load other information required for display
             */
            ViewBag.ServiceList = GetAvailableServices();
            ViewBag.ProviderList = GetServiceProviderSelectList(null);
            ViewBag.RequestedServices = db.RequestedServices.Where(s => s.PatientProfileID == rs.PatientProfileID).ToList();
            //
            return View(rs);
        }
        [HttpPost]
        public ActionResult RequestService([Bind(Include = "PatientProfileID, ServiceID, ProviderID")]RequestedService requestedService)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    requestedService.InsertDate = DateTime.Now;
                    db.RequestedServices.Add(requestedService);
                    //db.SaveChanges();
                    return RedirectToAction("CreatePatientProfile");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);

            }

            ViewBag.ServiceList = GetAvailableServices();
            ViewBag.ProviderList = GetServiceProviderSelectList(null);
            ViewBag.RequestedServices = GetRequestedServices(requestedService.PatientProfileID);
            //
            return View(requestedService);
        }
        //
        public List<RequestedService> GetRequestedServices(int patientProfileId)
        {
            return db.RequestedServices.Where(s => s.PatientProfileID == patientProfileId).ToList();
        }

        private SelectList GetServiceProviderSelectList(int? providerId)
        {
            var providerQuery = from c in db.ServiceProviders orderby c.ProviderName select c;
            return new SelectList(providerQuery, "ProviderID", "ProviderName", providerId);
        }
        private List<ConsultingService> GetAvailableServices()
        {
            return db.ConsultingServices.OrderBy(s => s.ServiceID).ToList();
        }
        private SelectList GetServiceSelectList(int? serviceId)
        {
            var serviceQuery = from c in db.ConsultingServices orderby c.ServiceID select c;
            return new SelectList(serviceQuery, "ServiceID", "ServiceName", serviceId);
        }

        private SelectList GetAvailablePatientProfiles()
        {
            int userId = 100;
            var profileQuery = from c in db.PatientProfiles
                               where c.UserID == userId
                               orderby c.DiseaseID
                               select new
                               {
                                   PatientProfileID = c.PatientProfileID,
                                   PatientProfileDesc = c.Age.ToString() + " years old, " + c.Gender.ToString() + " with " + c.Disease.Name
                               };
            return new SelectList(profileQuery, "PatientProfileID", "PatientProfileDesc", null);
        }
        //
        [HttpGet]
        [ChildActionOnly]
        public ActionResult EnterPatientDetail()
        {
            return PartialView();
        }
        //
        //
        //===============================================================================
        // BuildPatientProfile
        //===============================================================================
        [HttpGet]
        public ActionResult BuildPatientProfile()
        {
            populateSystem(null);
            PopulateDisease(null);
            PatientProfile pf = new PatientProfile();
            pf.Gender = new Gender();
            return View(pf);
        }
        private void PopulateDisease(int? diseaseId)
        {
            var diseaseQuery = from c in db.Diseases orderby c.Name select c;
            ViewBag.DiseaseList = new SelectList(diseaseQuery, "DiseaseID", "Name", diseaseId);

        }
        private void populateSystem(int? systemId)
        {
            var systemQuery = from c in db.BodySystems orderby c.Name select c;
            ViewBag.BodySystemList = new SelectList(systemQuery, "BodySystemID", "Name", systemId);
        }
        [HttpPost]
        public ActionResult BuildPatientProfile([Bind(Include = "Age, Gender, DateDiagnosed")]PatientProfile patientProfile)
        {
            try
            {
                //return RedirectToAction("BuildMedicalHistory");
                if (ModelState.IsValid)
                {
                    patientProfile.UserID = 100;
                    patientProfile.InsertDate = DateTime.Now;
                    db.PatientProfiles.Add(patientProfile);
                    //db.SaveChanges();
                    return RedirectToAction("BuildMedicalHistory");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
                logger.Error("dex:" + dex);
            }
            return View();
        }
        //
        // End Of BuildPatientProfile
        //======================================================================================

        [HttpGet]
        public ActionResult CollectPatientHistory()
        {
            return View();
        }
        //
        [HttpPost]
        public ActionResult CollectPatientHistory(int? sometning)
        {
            return RedirectToAction("UploadMedicalRecord");
        }

        //[HttpGet]
        //public ActionResult UploadFile()
        //{
        //    PatientProfile pf = new PatientProfile();
        //    pf.PatientProfileID = 1;  //colon cancer
        //    pf.DiseaseID = 14;
        //    ViewBag.Message = "Test file upload";
        //    ViewBag.RequiredRecords = GetRequiredRecords(pf);
        //    return View("UploadRecord");
        //}
        [HttpGet]
        public ActionResult MedicalRecords()
        {
            PatientProfile pf = new PatientProfile();
            pf.PatientProfileID = 1;  //colon cancer
            pf.DiseaseID = 14;
            ViewBag.Message = "Test file upload";
            ViewBag.RequiredRecords = GetRequiredRecords(pf);
            //
            UploadRecordViewData urvd = new UploadRecordViewData();
            //
            //urvd.RecordID = recordId;
            //urvd.RecordName = db.MedicalRecords.Find(recordId).Name;
            //return PartialView(urvd);
            //
            return View(urvd);
        }
        private List<MedicalRecordViewData> GetRequiredRecords(PatientProfile pf)
        {
            var disease = db.Diseases.Include(d => d.MedicalRecords).Where(d => d.DiseaseID == pf.DiseaseID).SingleOrDefault();
            var records = disease.MedicalRecords.OrderBy(s => s.Name);
            var patientRecords = db.PatientMedicalRecords.Where(p => p.PatientProfileID == pf.PatientProfileID);
            var patientUploadedRecords = new HashSet<int>(patientRecords.Select(c => c.MedicalRecordID));
            var viewModel = new List<MedicalRecordViewData>();
            foreach (var record in records)
            {
                viewModel.Add(new MedicalRecordViewData
                {
                    MedicalRecordID = record.MedicalRecordID,
                    RecordName = record.Name,
                    RecordDesc = record.Desc,
                    Uploaded = patientUploadedRecords.Contains(record.MedicalRecordID),
                    FileName = (patientUploadedRecords.Contains(record.MedicalRecordID)) ? patientRecords.Where(d => d.MedicalRecordID == record.MedicalRecordID).Single().FileName : "file_not_available.jpg"
                });

            }
            return viewModel;
        }

        //[HttpPost]
        //public JsonResult UploadPatientFile(HttpPostedFileBase file)
        //{
        //    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
        //    //string uploadPath = Server.MapPath("~/App_Data/uploads");

        //    //HttpPostedFileBase file = Request.Files["file"];

        //    string fileName = "undefined";
        //    if (file != null)
        //    {
        //        if (file.ContentLength > 102400)
        //        {
        //            ModelState.AddModelError("photo", "The size of the file should not exceed 100 KB");
        //            //ViewBag.Message = "The size of the file should not exceed 10 KB";
        //            //return View();
        //            return Json("The size of the file should not exceed 10 KB", JsonRequestBehavior.AllowGet);
        //        }

        //        var supportedTypes = new[] { "jpg", "jpeg", "png" };
        //        string fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
        //        if (!supportedTypes.Contains(fileExt))
        //        {
        //            ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //            //ViewBag.Message = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
        //            //return View();
        //            return Json("Invalid type. Only the following types (jpg, jpeg, png) are supported.", JsonRequestBehavior.AllowGet);
        //        }

        //        fileName = System.IO.Path.GetFileName(file.FileName);
        //        string uploadedFilePath = System.IO.Path.Combine(uploadPath, fileName);
        //        //file.SaveAs(uploadedFilePath);
        //    }

        //    //ViewBag.Message = "File name=" + file.FileName;
        //    //return PartialView();
        //    return Json(fileName, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        //{
        //    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
        //    //string uploadPath = Server.MapPath("~/App_Data/uploads");
        //    //HttpPostedFileBase file = Request.Files["file"];
        //    string fileName = "undefined";
        //    //
        //    if (files != null)
        //    {
        //        foreach (var file in files)
        //        {
        //            if (file.ContentLength > 102400)
        //            {
        //                ModelState.AddModelError("photo", "The size of the file should not exceed 100 KB");
        //                ViewBag.Message = "The size of the file should not exceed 100 KB";
        //                return View();
        //            }

        //            var supportedTypes = new[] { "jpg", "jpeg", "png" };
        //            string fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
        //            if (!supportedTypes.Contains(fileExt))
        //            {
        //                ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //                ViewBag.Message = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
        //                return View();
        //            }

        //            fileName = System.IO.Path.GetFileName(file.FileName);
        //            string uploadedFilePath = System.IO.Path.Combine(uploadPath, fileName);
        //            file.SaveAs(uploadedFilePath);
        //        }
        //    }
        //    ViewBag.Message = "Files were uploaded successfully";
        //    //return RedirectToAction("Index");
        //    return View();
        //}
        //[Bind(Include = "RecordName, RecordType, DatePerformed, HospitalPerformed, UserNotes")]UploadRecordViewData uploadedRecord
        //
        //
        [HttpPost]
        public ActionResult UploadFile([Bind(Include = "RecordID, DatePerformed, HospitalPerformed, UserNotes")]UploadRecordViewData uploadedRecord, HttpPostedFileBase File)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
                    string fileName = "";
                    string fileType = "";
                    //HttpPostedFileBase file = uploadedRecord.File;
                    HttpPostedFileBase file = File;

                    if (file != null)
                    {

                        fileName = System.IO.Path.GetFileName(file.FileName);
                        fileType = System.IO.Path.GetExtension(file.FileName).Substring(1);
                        //
                        error = saveUploadedFile(uploadPath, fileName, file);
                        //ViewBag.Message = error;
                        if (error.Length > 0)
                        {
                            ModelState.AddModelError("", error);
                            throw new Exception(error);
                        }
                        //
                        PatientProfile currPatientProfile = getCurrentPatientProfile();

                        PatientMedicalRecord ur = new PatientMedicalRecord();
                        //ur.RecordName = uploadedRecord.RecordName;
                        //ur.RecordType = uploadedRecord.RecordType;
                        ur.PatientProfileID = currPatientProfile.PatientProfileID;
                        ur.DatePerformed = uploadedRecord.DatePerformed;
                        ur.HospitalPerformed = uploadedRecord.HospitalPerformed;
                        ur.UserNotes = uploadedRecord.UserNotes;
                        ur.FileType = fileName;
                        ur.FileName = fileType;
                        ur.IsUploadedByUser = true;
                        ur.InternalCode = "";
                        ur.UploadDate = DateTime.Now;
                        ur.FileLocation = System.IO.Path.Combine(uploadPath, fileName);
                        //
                        db.PatientMedicalRecords.Add(ur);
                        ////db.SaveChanges();
                        //
                        //
                        //ViewBag.Message = "successful";
                        List<MedicalRecordViewData> ppRecords = GetRequiredRecords(currPatientProfile);
                        //
                        return PartialView("_ListRequiredRecords", ppRecords);

                        //return View();
                    }
                    else
                    {
                        error = "uploadedRecord.File is null";
                        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, error);
                    }
                }
                else
                {
                    error = "ModelState is invalid, details =" + ControllerHelper.getModelStateErrors(ModelState);
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

            return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, error);
            //return View();

        }
        //
        private string saveUploadedFile(string filePath, string fileName, HttpPostedFileBase fileData)
        {
            string error = "file data is null";
            if (fileData != null)
            {
                if (fileData.ContentLength > 102400)
                {
                    error = "The size of the file should not exceed 100 KB";
                    return error;
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                string fileExt = System.IO.Path.GetExtension(fileData.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    error = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
                    return error;
                }
                string uploadedFilePath = System.IO.Path.Combine(filePath, fileName);

                fileData.SaveAs(uploadedFilePath);
                error = "";
            }
            return error;
        }

        /// <summary>
        /// The followinh two routins retrieve other histories: social history and family history
        /// 
        /// </summary>
        /// <returns></returns>
        private SocialHistoryViewData GetSocialHistoryViewData(int patientProfileId)
        {
            SocialHistoryViewData ohvd = new SocialHistoryViewData();
            var patientSocialHistory = db.PatientSocialHistories.Find(patientProfileId);
            ohvd.SocialHistory = patientSocialHistory == null ? new PatientSocialHistory() : patientSocialHistory;
            ohvd.SubstanceTypeList = Enum.GetValues(typeof(SubstanceType)).Cast<SubstanceType>().Select(v => v.ToString()).ToList();
            ohvd.MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().Select(v => v.ToString()).ToList();
            ohvd.EmploymentStatusList = Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>().Select(v => v.ToString()).ToList();
            ohvd.ExerciseLevelList = Enum.GetValues(typeof(ExerciseLevel)).Cast<ExerciseLevel>().Select(v => v.ToString()).ToList();
            //
            return ohvd;
        }

        [HttpGet]
        public ActionResult _SocialHistory()
        {
            PatientProfile pf = getCurrentPatientProfile();
            //
            SocialHistoryViewData shvd = new SocialHistoryViewData();
            var patientSocialHistory = db.PatientSocialHistories.Find(pf.PatientProfileID);
            shvd.SocialHistory = patientSocialHistory == null ? new PatientSocialHistory() : patientSocialHistory;
            //shvd.FamilyMedicalHistoryList = GetFamilyHistoryViewData(pf.PatientProfileID);
            shvd.SubstanceTypeList = Enum.GetValues(typeof(SubstanceType)).Cast<SubstanceType>().Select(v => v.ToString()).ToList();
            shvd.MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().Select(v => v.ToString()).ToList();
            shvd.EmploymentStatusList = Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>().Select(v => v.ToString()).ToList();
            shvd.ExerciseLevelList = Enum.GetValues(typeof(ExerciseLevel)).Cast<ExerciseLevel>().Select(v => v.ToString()).ToList();
            //
            return PartialView("_SocialHistory", shvd);
        }

        //
        [HttpGet]
        public ActionResult _FamilyHistory()
        {
            PatientProfile pf = getCurrentPatientProfile();
            //
            List<FamilyHistoryViewData> familyHistoryList = GetFamilyHistoryViewData(pf.PatientProfileID);
            //
            return PartialView("_FamilyHistory", familyHistoryList);
        }
        //
        private List<FamilyHistoryViewData> GetFamilyHistoryViewData(int patientProfileId)
        {
            var allDiseases = db.Diseases.Where(s => s.UsedForFMH == true).OrderBy(d => d.Name);
            var familyHistories = db.PatientFamilyMedicalHistories.Where(s => s.PatientProfileID == patientProfileId);

            var ViewModel = new List<FamilyHistoryViewData>();
            if (familyHistories != null)
            {
                var familyDiseases = new HashSet<int>(familyHistories.Select(d => d.DiseaseID));
                foreach (var d in allDiseases)
                {
                    var fnvd = new FamilyHistoryViewData();

                    fnvd.DiseaseID = d.DiseaseID;
                    fnvd.DiseaseName = d.Name;
                    fnvd.IsInflicted = familyDiseases.Contains(d.DiseaseID);
                    fnvd.FamilyMembers = Enum.GetValues(typeof(FamilyMember)).Cast<FamilyMember>().Select(v => v.ToString()).ToList();

                    var fmembers = new List<string>();
                    if (familyDiseases.Contains(d.DiseaseID))
                    {
                        var fmrbs = familyHistories.Where(e => e.DiseaseID == d.DiseaseID).ToList();
                        foreach (var mrb in fmrbs)
                        {
                            fmembers.Add(Enum.GetName(typeof(FamilyMember), (int)mrb.FamilyMember));
                        }
                    }
                    fnvd.InflictingMembers = fmembers;

                    ViewModel.Add(fnvd);
                }
            }
            return ViewModel;
        }

        //
        [HttpGet]
        public JsonResult GetDiseasesBySystem(int bodySystemId)
        {
            var diseasesBySystem = from s in db.Diseases where s.BodySystemID == bodySystemId select new { s.DiseaseID, s.Name };
            return Json(diseasesBySystem.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDiseaseNameList(string term)
        {
            var diseasesBySystem = from s in db.Diseases where s.Name.Contains(term) select new { id = s.DiseaseID, value = s.Name, label = s.Name };
            return Json(diseasesBySystem.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        //
        //====================================================================================================
        //   PostQuestion - three
        //====================================================================================================
        //
        [HttpGet]
        public ActionResult PatientQuestions()
        {
            int patientProfileId = 1;
            List<PatientQuestion> pQuestions = GetPatientPostedQuestions(patientProfileId);
            ViewBag.QAList = pQuestions;
            //
            PatientQuestion pQuestion = new PatientQuestion();
            //
            return View(pQuestion);
        }
        //
        [HttpPost]
        public ActionResult PatientQuestions([Bind(Include = "QuestionAsked")]PatientQuestion pQuestion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //pQuestion.DateAsked = DateTime.Parse("2015-04-21");
                    //pQuestion.Answer = "(Not yet)";
                    //db.PatientQuestions.Add(pQuestion);
                    //db.SaveChanges();

                    int patientProfileId = 1;
                    List<PatientQuestion> pQuestions = GetPatientPostedQuestions(patientProfileId);
                    ViewBag.QAList = pQuestions;
                    return View(pQuestion);
                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
            return View();
        }
        //

        //
        public List<PatientQuestion> GetPatientPostedQuestions(int patientProfileId)
        {
            return db.PatientQuestions.Where(s => s.PatientProfileID == patientProfileId).OrderBy(p => p.DateAsked).ToList();
        }

        public List<MedicalHistoryViewData> GetPatientMedicalHistoryViewData(int patientProfileId)
        {
            var allDieases = db.Diseases.Where(a => a.UsedForPMH == true).OrderBy(s => s.Name);
            var patientPastDiseaseList = db.PatientMedicalHistories.Where(d => d.PatientProfileID == patientProfileId).ToList();
            var patientDieaseHistories = new HashSet<int>(patientPastDiseaseList.Select(f => f.DiseaseID));
            var viewModel = new List<MedicalHistoryViewData>();
            foreach (var ds in allDieases)
            {
                viewModel.Add(new MedicalHistoryViewData
                {
                    DiseaseID = ds.DiseaseID,
                    DiseaseName = ds.Name,
                    IsSelected = patientDieaseHistories.Contains(ds.DiseaseID)
                });
            }
            return viewModel;
        }

        public List<SystemReviewViewData> GetPatientSystemReviewViewData(int patientProfileId)
        {
            var allSystems = db.BodySystems.OrderBy(d => d.BodySystemID);
            var allSymtpoms = db.Symptoms.OrderBy(d => d.BodySystemID);
            var patientSymptoms = db.PatientSystemReviews.Where(s => s.PatientProfileID == patientProfileId).ToList();
            var patientSymptomIds = new HashSet<int>(patientSymptoms.Select(s => s.DiagnosticFactorID));
            var viewModel = new List<SystemReviewViewData>();

            foreach (var bs in allSystems)
            {
                var mySr = new SystemReviewViewData();
                mySr.SystemName = bs.Name;
                mySr.SymptomReviewViewDataList = new List<SymptomReviewViewData>();
                foreach (var sptm in allSymtpoms.Where(s => s.BodySystemID == bs.BodySystemID))
                {
                    mySr.SymptomReviewViewDataList.Add(new SymptomReviewViewData
                    {
                        DiagnosticFactorID = sptm.DiagnosticFactorID,
                        SymtomName = sptm.Name,
                        IsSelected = patientSymptomIds.Contains(sptm.DiagnosticFactorID)
                    });
                }
                viewModel.Add(mySr);

            }
            return viewModel;
        }
        public List<SurgicalHistoryViewData> GetPatientSurgicalHistoryViewData(int patientProfileId)
        {
            var allSurgeries = db.Treatments.Where(s => s.Modality == TreatmentModality.Surgery).Where(g => g.UsedForPMH == true).OrderBy(s => s.Name);
            var patientPastSurgeries = db.PatientSurgicalHistories.Where(d => d.PatientProfileID == patientProfileId).ToList();
            var patientSurgeryIds = new HashSet<int>(patientPastSurgeries.Select(d => d.TreatmentID));
            var viewModel = new List<SurgicalHistoryViewData>();
            foreach (var sh in allSurgeries)
            {
                viewModel.Add(new SurgicalHistoryViewData
                {
                    TreatmentID = sh.TreatmentID,
                    SurgeryName = sh.Name,
                    IsSelected = patientSurgeryIds.Contains(sh.TreatmentID)
                });
            }
            return viewModel;
        }
        [HttpGet]
        public ActionResult _CreatePP()
        {
            ViewBag.ServiceList = GetAvailableServices();
            ViewBag.ProviderList = GetServiceProviderSelectList(null);
            return PartialView();
        }

        [HttpPost]
        public ActionResult _CreatePP(int id)
        {
            return RedirectToAction("MotherBoard");
        }

        /*
         *********************************************************************
         Keep this is the sole location to get the current PatientProfile
         * *******************************************************************
         */
        private PatientProfile getCurrentPatientProfile()
        {
            int patientProfileId = 1;
            PatientProfile currPatientProfile = db.PatientProfiles.Include(s => s.RequestedServices).Where(d => d.PatientProfileID == patientProfileId).Single();

            currPatientProfile.DiseaseID = 1;  /*override since only 1 has required records
                                                */
            return currPatientProfile;
        }
        //

        //
        //====================================================================================================
        //   Upload Medical Record - three
        //====================================================================================================
        [HttpGet]
        public ActionResult GetUploadFileView(int recordId)
        {
            UploadRecordViewData urvd = new UploadRecordViewData();
            urvd.RecordID = recordId;
            urvd.RecordName = db.MedicalRecords.Find(recordId).Name;
            return PartialView("_UploadFileView", urvd);
        }
	}
}