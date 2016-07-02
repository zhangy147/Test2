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

namespace WebTest.Controllers
{
    public class ServiceManagerController : BaseController
    {
     //   private SiteDbContext db = new SiteDbContext();
     //   readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    //    [HttpGet]
    //    public ActionResult Index(int? serviceId)
    //    {

    //        if (serviceId == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        ServiceManagerViewData smvd = new ServiceManagerViewData();
    //        //smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();

    //        //smvd.RequestedServices = GetRequestedServices(currPatientProfile);
    //        //smvd.AvailableProviders = GetServiceProviderSelectList(null);
    //        smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();

    //        //
    //        PatientProfile cpp = getCurrentPatientProfile();
    //        //
    //        //customize the current petient profile
    //        cpp.RequestedServices = new List<RequestedService>();
    //        cpp.PatientProfileID = 1;
    //        cpp.DiseaseID = 14;
    //        cpp.Disease = db.Diseases.Find(cpp.DiseaseID);
    //        //
    //        smvd.SocialHistory = GetSocialHistoryViewData(cpp.PatientProfileID);
    //        //
    //        smvd.CurrentPatientProfile = cpp;
    //        //
    //        logger.Error("This is a test for log4net app");
    //        //
    //        return View(smvd);
    //    }

    //    [HttpGet]
    //    public ActionResult Thumbnail()
    //    {

    //        ImageViewData ivd = new ImageViewData();
    //        ivd.Width = 50;
    //        ivd.Height = 50;
    //        ivd.FileName = "mri_example.jpg";

    //        return View(ivd);
    //    }

    //    [HttpGet]
    //    public ThumbnailActionResult GetThumbnail(string imageName, int width, int height)
    //    {
    //        ThumbnailController th = new ThumbnailController();
    //        return th.Generate(width, height, imageName);
    //    }

    //    //
    //    [HttpGet]
    //    public ActionResult MotherBoard(string error)
    //    {
    //        if (error != "")
    //        {
    //            ViewBag.Error = error;
    //        }
    //        ServiceManagerViewData smvd = new ServiceManagerViewData();
    //        //
    //        smvd.CurrentPatientProfile = getCurrentPatientProfile();
    //        //
    //        smvd.AvailablePatientProfiles = GetAvailablePatientProfiles();
    //        //smvd.PatientQuerstions = GetPatientPostedQuestions(smvd.CurrentPatientProfile.PatientProfileID);
    //        //smvd.RequestedServices = GetRequestedServices(smvd.CurrentPatientProfile.PatientProfileID);
    //        smvd.DiseaseHistories = GetPatientDiseaseHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
    //        smvd.SurgicalHistories = GetPatientSurgicalHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
    //        smvd.SystemReviews = GetPatientSystemReviewViewData(smvd.CurrentPatientProfile.PatientProfileID);
    //        //smvd.MedicalRecords = GetRequiredRecords(smvd.CurrentPatientProfile);
    //        //smvd.FamilyHistories = GetFamilyHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
    //        smvd.SocialHistory = GetSocialHistoryViewData(smvd.CurrentPatientProfile.PatientProfileID);
    //        //

    //        return View(smvd);
    //    }

    //    //
    //    // POST: /UserService/Delete/5

    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //    [HttpGet]
    //    public ActionResult SignPrivacyPolicy(string requestedService)
    //    {
    //        ViewBag.Service = requestedService;
    //        return View();
    //    }
    //    [HttpPost]
    //    public ActionResult SignPrivacyPolicy(string requestedService, string id)
    //    {
    //        if (string.Compare(requestedService, "SecondOpinion", true) == 0)
    //        {
    //            return RedirectToAction("EnterSecondOpinion", "SecondOpinion");
    //        }
    //        else if (string.Compare(requestedService, "LiveConsulting", true) == 0)
    //        {
    //            return RedirectToAction("EnterLiveConsulting", "LiveConsulting");
    //        }



    //        else if (string.Compare(requestedService, "TreatmentReport", true) == 0)
    //        {
    //            return RedirectToAction("EnterTreatmentReport", "TreatmentReport");
    //        }
    //        else
    //            return View();

    //    }
    //    [HttpGet]
    //    public ActionResult RequestService(int? serviceId)
    //    {
    //        if (serviceId == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        /*
    //         * Declare a RequestedService object and pass it into View
    //         */
    //        RequestedService rs = new RequestedService();
    //        rs.ServiceID = 3;
    //        rs.PatientProfileID = 1;
    //        /*
    //         * load other information required for display
    //         */
    //        ViewBag.ServiceList = GetAvailableServices();
    //        ViewBag.ProviderList = GetServiceProviderSelectList(null);
    //        ViewBag.RequestedServices = db.RequestedServices.Where(s => s.PatientProfileID == rs.PatientProfileID).ToList();
    //        //
    //        return View(rs);
    //    }
    //    [HttpPost]
    //    public ActionResult RequestService([Bind(Include = "PatientProfileID, ServiceID, ProviderID")]RequestedService requestedService)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                requestedService.InsertDate = DateTime.Now;
    //                db.RequestedServices.Add(requestedService);
    //                //db.SaveChanges();
    //                return RedirectToAction("CreatePatientProfile");
    //            }
    //        }
    //        catch (RetryLimitExceededException dex)
    //        {
    //            //Log the error (uncomment dex variable name and add a line here to write a log.
    //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);

    //        }

    //        ViewBag.ServiceList = GetAvailableServices();
    //        ViewBag.ProviderList = GetServiceProviderSelectList(null);
    //        ViewBag.RequestedServices = GetRequestedServices(requestedService.PatientProfileID);
    //        //
    //        return View(requestedService);
    //    }
    //    //
    //    public List<RequestedService> GetRequestedServices(int patientProfileId)
    //    {
    //        return db.RequestedServices.Where(s => s.PatientProfileID == patientProfileId).ToList();
    //    }

    //    private SelectList GetServiceProviderSelectList(int? providerId)
    //    {
    //        var providerQuery = from c in db.ServiceProviders orderby c.ProviderName select c;
    //        return new SelectList(providerQuery, "ProviderID", "ProviderName", providerId);
    //    }
    //    private List<ConsultingService> GetAvailableServices()
    //    {
    //        return db.ConsultingServices.OrderBy(s => s.ServiceID).ToList();
    //    }
    //    private SelectList GetServiceSelectList(int? serviceId)
    //    {
    //        var serviceQuery = from c in db.ConsultingServices orderby c.ServiceID select c;
    //        return new SelectList(serviceQuery, "ServiceID", "ServiceName", serviceId);
    //    }

    //    private SelectList GetAvailablePatientProfiles()
    //    {
    //        int userId = 100;
    //        var profileQuery = from c in db.PatientProfiles
    //                           where c.UserID == userId
    //                           orderby c.DiseaseID
    //                           select new
    //                           {
    //                               PatientProfileID = c.PatientProfileID,
    //                               PatientProfileDesc = c.Age.ToString() + " years old, " + c.Gender.ToString() + " with " + c.Disease.Name
    //                           };
    //        return new SelectList(profileQuery, "PatientProfileID", "PatientProfileDesc", null);
    //    }
    //    //
    //    [HttpGet]
    //    [ChildActionOnly]
    //    public ActionResult EnterPatientDetail()
    //    {
    //        return PartialView();
    //    }
    //    //
    //    //
    //    //===============================================================================
    //    // BuildPatientProfile
    //    //===============================================================================
    //    [HttpGet]
    //    public ActionResult BuildPatientProfile()
    //    {
    //        populateSystem(null);
    //        PopulateDisease(null);
    //        PatientProfile pf = new PatientProfile();
    //        pf.Gender = new Gender();
    //        //return View(pf);
    //        return PartialView("_PatientProfile", pf);
    //    }
    //    private void PopulateDisease(int? diseaseId)
    //    {
    //        var diseaseQuery = from c in db.Diseases orderby c.Name select c;
    //        ViewBag.DiseaseList = new SelectList(diseaseQuery, "DiseaseID", "Name", diseaseId);

    //    }
    //    private void populateSystem(int? systemId)
    //    {
    //        var systemQuery = from c in db.BodySystems orderby c.Name select c;
    //        ViewBag.BodySystemList = new SelectList(systemQuery, "BodySystemID", "Name", systemId);
    //    }
    //    [HttpPost]
    //    public ActionResult BuildPatientProfile([Bind(Include = "Age, Gender, DateDiagnosed")]PatientProfile patientProfile)
    //    {
    //        try
    //        {
    //            //return RedirectToAction("BuildMedicalHistory");
    //            if (ModelState.IsValid)
    //            {
    //                patientProfile.UserID = 100;
    //                patientProfile.InsertDate = DateTime.Now;
    //                db.PatientProfiles.Add(patientProfile);
    //                //db.SaveChanges();
    //                return RedirectToAction("BuildMedicalHistory");
    //            }
    //        }
    //        catch (RetryLimitExceededException dex)
    //        {
    //            //Log the error (uncomment dex variable name and add a line here to write a log.
    //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
    //            logger.Error("dex:" + dex);
    //        }
    //        return View();
    //    }
    //    //
    //    // End Of BuildPatientProfile
    //    //======================================================================================

    //    [HttpGet]
    //    public ActionResult CollectPatientHistory()
    //    {
    //        return View();
    //    }
    //    //
    //    [HttpPost]
    //    public ActionResult CollectPatientHistory(int? sometning)
    //    {
    //        return RedirectToAction("UploadMedicalRecord");
    //    }

    //    //[HttpGet]
    //    //public ActionResult UploadFile()
    //    //{
    //    //    PatientProfile pf = new PatientProfile();
    //    //    pf.PatientProfileID = 1;  //colon cancer
    //    //    pf.DiseaseID = 14;
    //    //    ViewBag.Message = "Test file upload";
    //    //    ViewBag.RequiredRecords = GetRequiredRecords(pf);
    //    //    return View("UploadRecord");
    //    //}
    //    [HttpGet]
    //    public ActionResult MedicalRecords()
    //    {
    //        PatientProfile pf = new PatientProfile();
    //        pf.PatientProfileID = 1;  //colon cancer
    //        pf.DiseaseID = 14;
    //        ViewBag.Message = "Test file upload";
    //        ViewBag.RequiredRecords = GetRequiredRecords(pf);
    //        //
    //        MedicalRecordViewData urvd = new MedicalRecordViewData();
    //        //
    //        //urvd.RecordID = recordId;
    //        //urvd.RecordName = db.MedicalRecords.Find(recordId).Name;
    //        //return PartialView(urvd);
    //        //
    //        return View(urvd);
    //    }


    //    //[HttpPost]
    //    //public JsonResult UploadPatientFile(HttpPostedFileBase file)
    //    //{
    //    //    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
    //    //    //string uploadPath = Server.MapPath("~/App_Data/uploads");

    //    //    //HttpPostedFileBase file = Request.Files["file"];

    //    //    string fileName = "undefined";
    //    //    if (file != null)
    //    //    {
    //    //        if (file.ContentLength > 102400)
    //    //        {
    //    //            ModelState.AddModelError("photo", "The size of the file should not exceed 100 KB");
    //    //            //ViewBag.Message = "The size of the file should not exceed 10 KB";
    //    //            //return View();
    //    //            return Json("The size of the file should not exceed 10 KB", JsonRequestBehavior.AllowGet);
    //    //        }

    //    //        var supportedTypes = new[] { "jpg", "jpeg", "png" };
    //    //        string fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
    //    //        if (!supportedTypes.Contains(fileExt))
    //    //        {
    //    //            ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
    //    //            //ViewBag.Message = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
    //    //            //return View();
    //    //            return Json("Invalid type. Only the following types (jpg, jpeg, png) are supported.", JsonRequestBehavior.AllowGet);
    //    //        }

    //    //        fileName = System.IO.Path.GetFileName(file.FileName);
    //    //        string uploadedFilePath = System.IO.Path.Combine(uploadPath, fileName);
    //    //        //file.SaveAs(uploadedFilePath);
    //    //    }

    //    //    //ViewBag.Message = "File name=" + file.FileName;
    //    //    //return PartialView();
    //    //    return Json(fileName, JsonRequestBehavior.AllowGet);
    //    //}

    //    //[HttpPost]
    //    //public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
    //    //{
    //    //    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
    //    //    //string uploadPath = Server.MapPath("~/App_Data/uploads");
    //    //    //HttpPostedFileBase file = Request.Files["file"];
    //    //    string fileName = "undefined";
    //    //    //
    //    //    if (files != null)
    //    //    {
    //    //        foreach (var file in files)
    //    //        {
    //    //            if (file.ContentLength > 102400)
    //    //            {
    //    //                ModelState.AddModelError("photo", "The size of the file should not exceed 100 KB");
    //    //                ViewBag.Message = "The size of the file should not exceed 100 KB";
    //    //                return View();
    //    //            }

    //    //            var supportedTypes = new[] { "jpg", "jpeg", "png" };
    //    //            string fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
    //    //            if (!supportedTypes.Contains(fileExt))
    //    //            {
    //    //                ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
    //    //                ViewBag.Message = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
    //    //                return View();
    //    //            }

    //    //            fileName = System.IO.Path.GetFileName(file.FileName);
    //    //            string uploadedFilePath = System.IO.Path.Combine(uploadPath, fileName);
    //    //            file.SaveAs(uploadedFilePath);
    //    //        }
    //    //    }
    //    //    ViewBag.Message = "Files were uploaded successfully";
    //    //    //return RedirectToAction("Index");
    //    //    return View();
    //    //}
    //    //[Bind(Include = "RecordName, RecordType, DatePerformed, HospitalPerformed, UserNotes")]UploadRecordViewData uploadedRecord
    //    //
    //    //
    //    [HttpPost]
    //    public ActionResult UploadFile([Bind(Include = "RecordID, DatePerformed, HospitalPerformed, UserNotes")]MedicalRecordViewData uploadedRecord, HttpPostedFileBase File)
    //    {
    //        string error = "";
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
    //                string fileName = "";
    //                string fileType = "";
    //                //HttpPostedFileBase file = uploadedRecord.File;
    //                HttpPostedFileBase file = File;

    //                if (file != null)
    //                {

    //                    fileName = System.IO.Path.GetFileName(file.FileName);
    //                    fileType = System.IO.Path.GetExtension(file.FileName).Substring(1);
    //                    //
    //                    error = saveUploadedFile(uploadPath, fileName, file);
    //                    //ViewBag.Message = error;
    //                    if (error.Length > 0)
    //                    {
    //                        ModelState.AddModelError("", error);
    //                        throw new Exception(error);
    //                    }
    //                    //
    //                    PatientProfile currPatientProfile = getCurrentPatientProfile();

    //                    PatientMedicalRecord ur = new PatientMedicalRecord();
    //                    //ur.RecordName = uploadedRecord.RecordName;
    //                    //ur.RecordType = uploadedRecord.RecordType;
    //                    ur.PatientProfileID = currPatientProfile.PatientProfileID;
    //                    ur.DateReceived = (System.DateTime)uploadedRecord.DateReceived;
    //                    ur.HospitalReceived = uploadedRecord.HospitalReceived;
    //                    ur.PatientNotes = uploadedRecord.UserNotes;
    //                    ur.FileType = fileName;
    //                    ur.FileName = fileType;
    //                    ur.IsUploadedByUser = true;
    //                    ur.InternalCode = "";
    //                    ur.UploadDate = DateTime.Now;
    //                    ur.FileLocation = System.IO.Path.Combine(uploadPath, fileName);
    //                    //
    //                    db.PatientMedicalRecords.Add(ur);
    //                    ////db.SaveChanges();
    //                    //
    //                    //
    //                    //ViewBag.Message = "successful";
    //                    List<RequiredMedicalRecordViewData> ppRecords = GetRequiredRecords(currPatientProfile);
    //                    //
    //                    return PartialView("_ListRequiredRecords", ppRecords);

    //                    //return View();
    //                }
    //                else
    //                {
    //                    error = "uploadedRecord.File is null";
    //                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, error);
    //                }
    //            }
    //            else
    //            {
    //                error = "ModelState is invalid, details =" + ControllerHelper.getModelStateErrors(ModelState);
    //            }
    //        }
    //        catch (RetryLimitExceededException dex)
    //        {
    //            //Log the error (uncomment dex variable name and add a line here to write a log.
    //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
    //            error = "RetryLimitExceededException";
    //        }
    //        catch (Exception something)
    //        {
    //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + something);
    //            error = "Exception";
    //        }

    //        return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, error);
    //        //return View();

    //    }
    //    //
    //    private string saveUploadedFile(string filePath, string fileName, HttpPostedFileBase fileData)
    //    {
    //        string error = "file data is null";
    //        if (fileData != null)
    //        {
    //            if (fileData.ContentLength > 102400)
    //            {
    //                error = "The size of the file should not exceed 100 KB";
    //                return error;
    //            }

    //            var supportedTypes = new[] { "jpg", "jpeg", "png" };
    //            string fileExt = System.IO.Path.GetExtension(fileData.FileName).Substring(1);
    //            if (!supportedTypes.Contains(fileExt))
    //            {
    //                error = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
    //                return error;
    //            }
    //            string uploadedFilePath = System.IO.Path.Combine(filePath, fileName);

    //            fileData.SaveAs(uploadedFilePath);
    //            error = "";
    //        }
    //        return error;
    //    }

    //    /// <summary>
    //    /// The followinh two routins retrieve other histories: social history and family history
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    private PatientSocialHistory GetSocialHistoryViewData(int patientProfileId)
    //    {
    //        PatientSocialHistory ohvd = new PatientSocialHistory();
    //        var patientSocialHistory = db.PatientSocialHistories.Find(patientProfileId);
    //        //ohvd.SocialHistory = patientSocialHistory == null ? new PatientSocialHistory() : patientSocialHistory;
    //        //ohvd.SubstanceList = Enum.GetValues(typeof(Substance)).Cast<Substance>().ToList();
    //        //ohvd.MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().ToList();
    //        //ohvd.EmploymentStatusList = Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>().ToList();
    //        //ohvd.ExerciseLevelList = Enum.GetValues(typeof(ExerciseLevel)).Cast<ExerciseLevel>().ToList();
    //        //
    //        return ohvd;
    //    }

    //    [HttpGet]
    //    public ActionResult _SocialHistory()
    //    {
    //        //PatientProfile pf = getCurrentPatientProfile();
    //        ////
    //        //PatientSocialHistoryViewData shvd = new PatientSocialHistoryViewData();
    //        //var patientSocialHistory = db.PatientSocialHistories.Find(pf.PatientProfileID);
    //        //shvd.SocialHistory = patientSocialHistory == null ? new PatientSocialHistory() : patientSocialHistory;
    //        ////shvd.FamilyMedicalHistoryList = GetFamilyHistoryViewData(pf.PatientProfileID);
    //        //shvd.SubstanceList = Enum.GetValues(typeof(Substance)).Cast<Substance>().ToList();
    //        //shvd.MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().ToList();
    //        //shvd.EmploymentStatusList = Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>().ToList();
    //        //shvd.ExerciseLevelList = Enum.GetValues(typeof(ExerciseLevel)).Cast<ExerciseLevel>().ToList();
    //        ////
    //        //return PartialView("_SocialHistory", shvd);
    //        return PartialView("_SocialHistory");
    //    }

    //    //

    //    //
    //    [HttpGet]
    //    public JsonResult GetDiseasesBySystem(int bodySystemId)
    //    {
    //        var diseasesBySystem = from s in db.Diseases where s.BodySystemID == bodySystemId select new { s.DiseaseID, s.Name };
    //        return Json(diseasesBySystem.ToList(), JsonRequestBehavior.AllowGet);
    //    }

    //    //
    //    //
    //    //====================================================================================================
    //    //   PostQuestion - three
    //    //====================================================================================================
    //    //
    //    [HttpGet]
    //    public ActionResult PatientQuestions()
    //    {
    //        int patientProfileId = 1;
    //        List<PatientQuestion> pQuestions = GetPatientPostedQuestions(patientProfileId);
    //        ViewBag.QAList = pQuestions;
    //        //
    //        PatientQuestion pQuestion = new PatientQuestion();
    //        //
    //        return View(pQuestion);
    //    }
    //    //
    //    [HttpPost]
    //    public ActionResult PatientQuestions([Bind(Include = "QuestionAsked")]PatientQuestion pQuestion)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                //pQuestion.DateAsked = DateTime.Parse("2015-04-21");
    //                //pQuestion.Answer = "(Not yet)";
    //                //db.PatientQuestions.Add(pQuestion);
    //                //db.SaveChanges();

    //                int patientProfileId = 1;
    //                List<PatientQuestion> pQuestions = GetPatientPostedQuestions(patientProfileId);
    //                ViewBag.QAList = pQuestions;
    //                return View(pQuestion);
    //            }
    //        }
    //        catch (RetryLimitExceededException dex)
    //        {
    //            //Log the error (uncomment dex variable name and add a line here to write a log.
    //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
    //        }
    //        return View();
    //    }
    //    //

    //    //
    //    public List<PatientQuestion> GetPatientPostedQuestions(int patientProfileId)
    //    {
    //        return db.PatientQuestions.Where(s => s.PatientProfileID == patientProfileId).OrderBy(p => p.DateAsked).ToList();
    //    }

    //    public List<PatientDiseaseHistoryViewData> GetPatientDiseaseHistoryViewData(int patientProfileId)
    //    {
    //        //var allDieases = db.Diseases.Where(a => a.UsedForPMH == true).OrderBy(s => s.Name);
    //        //var patientPastDiseaseList = db.PatientMedicalHistories.Where(d => d.PatientProfileID == patientProfileId).ToList();
    //        //var patientDieaseHistories = new HashSet<int>(patientPastDiseaseList.Select(f => f.DiseaseID));
    //        //var viewModel = new List<PatientDiseaseHistoryViewData>();
    //        //foreach (var ds in allDieases)
    //        //{
    //        //    viewModel.Add(new PatientDiseaseHistoryViewData
    //        //    {
    //        //        DiseaseID = ds.DiseaseID,
    //        //        DiseaseName = ds.Name,
    //        //        IsSelected = patientDieaseHistories.Contains(ds.DiseaseID)
    //        //    });
    //        //}
    //        return null;
    //    }

    //    public List<SystemReviewViewData> GetPatientSystemReviewViewData(int patientProfileId)
    //    {
    //        //var allSystems = db.BodySystems.OrderBy(d => d.BodySystemID);
    //        //var allSymtpoms = db.Symptoms.OrderBy(d => d.BodySystemID);
    //        //var patientSymptoms = db.PatientSystemReviews.Where(s => s.PatientProfileID == patientProfileId).ToList();
    //        //var patientSymptomIds = new HashSet<int>(patientSymptoms.Select(s => s.DiagnosticFactorID));
    //        //var viewModel = new List<PatientSystemReviewViewData>();

    //        //foreach (var bs in allSystems)
    //        //{
    //        //    var mySr = new PatientSystemReviewViewData();
    //        //    mySr.SystemName = bs.Name;
    //        //    mySr.SymptomReviewViewDataList = new List<PatientSymptomReviewViewData>();
    //        //    foreach (var sptm in allSymtpoms.Where(s => s.BodySystemID == bs.BodySystemID))
    //        //    {
    //        //        mySr.SymptomReviewViewDataList.Add(new PatientSymptomReviewViewData
    //        //        {
    //        //            DiagnosticFactorID = sptm.DiagnosticFactorID,
    //        //            SymtomName = sptm.Name,
    //        //            IsSelected = patientSymptomIds.Contains(sptm.DiagnosticFactorID)
    //        //        });
    //        //    }
    //        //    viewModel.Add(mySr);

    //        //}
    //        return null;
    //    }
    //    public List<PatientSurgicalHistoryViewData> GetPatientSurgicalHistoryViewData(int patientProfileId)
    //    {
    //        //int diseaseId = 4;

    //        //int mSpecialtyID = db.DiseaseAssignments
    //        //    .Where(s => s.DiseaseID == diseaseId)
    //        //    .Where(d => d.IsPrimary == true).Single().MedicalSpecialtyID;

    //        //var allSurgeries = db.SurgicalHistories
    //        //    .Include(d => d.Treatment)
    //        //    .Where(g => g.MedicalSpecialtyID == mSpecialtyID).OrderBy(s => s.Treatment.Name);

    //        //var patientPastSurgeries = db.PatientSurgicalHistories.Where(d => d.PatientProfileID == patientProfileId).ToList();
    //        //var patientSurgeryIds = new HashSet<int>(patientPastSurgeries.Select(d => d.TreatmentID));
    //        //var viewModel = new List<PatientSurgicalHistoryViewData>();
    //        //foreach (var sh in allSurgeries)
    //        //{
    //        //    viewModel.Add(new PatientSurgicalHistoryViewData
    //        //    {
    //        //        TreatmentID = sh.TreatmentID,
    //        //        SurgeryName = sh.Treatment.Name,
    //        //        IsSelected = patientSurgeryIds.Contains(sh.TreatmentID)
    //        //    });
    //        //}
    //        return null;
    //    }
    //    [HttpGet]
    //    public ActionResult _CreatePP()
    //    {
    //        ViewBag.ServiceList = GetAvailableServices();
    //        ViewBag.ProviderList = GetServiceProviderSelectList(null);
    //        return PartialView();
    //    }

    //    [HttpPost]
    //    public ActionResult _CreatePP(int id)
    //    {
    //        return RedirectToAction("MotherBoard");
    //    }

    //    /*
    //     *********************************************************************
    //     Keep this is the sole location to get the current PatientProfile
    //     * *******************************************************************
    //     */
    //    private PatientProfile getCurrentPatientProfile()
    //    {
    //        int patientProfileId = 1;
    //        PatientProfile currPatientProfile = db.PatientProfiles.Include(s => s.RequestedServices).Where(d => d.PatientProfileID == patientProfileId).Single();

    //        currPatientProfile.DiseaseID = 1;  /*override since only 1 has required records
    //                                            */
    //        return currPatientProfile;
    //    }
    //    //

    //    //
    //    //====================================================================================================
    //    //   Upload Medical Record - three
    //    //====================================================================================================
    //    [HttpGet]
    //    public ActionResult GetUploadFileView()
    //    {
    //        MedicalRecordViewData urvd = new MedicalRecordViewData();
    //        int recordId = 3;
    //        urvd.RecordID = recordId;
    //        urvd.RecordName = db.MedicalRecords.Find(recordId).Name;
    //        logger.Debug("record name: " + urvd.RecordName);
    //        return PartialView("_UploadFileView", urvd);
    //    }
    }
}