using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Net;
//
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;

namespace WebTest.Controllers
{
    public class MedicalRecordController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

 
        [HttpGet]
        public ActionResult ShowUploadMedicalRecord()
        {
            logger.Debug("ShowUploadMedicalRecord");
            int diseaseId = GetCurrentDiseaseID();
            int pProfileId = GetCurrentPatientProfileID();
            logger.Debug("pProfielId=" + pProfileId);
            MedicalRecordViewData mRecordViewData = new MedicalRecordViewData();
            //
            pProfileId = 2;
            diseaseId = 4;
            ViewBag.UnUploadedRecords = MedicalRecordManager.Instance.GetUnuploadedMedicalRecordsSelectList(pProfileId, diseaseId);
            logger.Debug("ViewBag.UnUploadedRecords");
            return PartialView("_UploadMedicalRecordTab", mRecordViewData);
        }
        //
        [HttpGet]
        public ActionResult GetUploadedMedicalRecords()
        {
            int pProfileId = GetCurrentPatientProfileID();
            List<UploadedMedicalRecordViewData> uploaded = MedicalRecordManager.Instance.GetUploadedMedicalRecordViewDataList(pProfileId);
            return PartialView("_UploadedMedicalRecordsTab", uploaded);
        }
        //
        [HttpGet]
        public ActionResult GetRequiredMedicalRecords()
        {
            int diseaseId = GetCurrentDiseaseID();

            logger.Debug("diseaseId=" + diseaseId);

            List<RequiredMedicalRecordViewData> required = MedicalRecordManager.Instance.GetRequiredMedicalRecordViewDataList(diseaseId);

            logger.Debug("required medical records=" + required.Count());

            return PartialView("_RequiredMedicalRecordsTab", required);
        }

        [HttpGet]
        public ThumbnailActionResult GetRecordThumbnail(string imageName, int width, int height)
        {
            ThumbnailController th = new ThumbnailController();
            return th.Generate(width, height, imageName);
        }

        [HttpPost]
        public ActionResult UploadMedicalRecord(MedicalRecordViewData mRecord)
        {
            string error = "";
            logger.Debug("UploadMedicalRecord");
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Debug("MedicalRecordID=" + mRecord.RecordID);
                    logger.Debug("DateReceived=" + mRecord.DateReceived);
                    logger.Debug("Hospital=" + mRecord.IssuingHospital);
                    //
                    string uploadPath = @"C:/Users/ZhangY/STUDY_FILES/";
                    string fileName = "";
                    string fileType = "";
                    //HttpPostedFileBase file = uploadedRecord.File;
                    List<HttpPostedFileBase> files = mRecord.RecordFiles;

                    if (files != null)
                    {
                        logger.Debug("file is not null");
                        foreach (var f in files)
                        {
                            fileName = System.IO.Path.GetFileName(f.FileName);
                            fileType = System.IO.Path.GetExtension(f.FileName).Substring(1);

                            logger.Debug("fileName=" + fileName);
                            logger.Debug("fileType=" + fileType);

                        }
                        


                        //fileName = System.IO.Path.GetFileName(files[1].FileName);
                        //fileType = System.IO.Path.GetExtension(files[1].FileName).Substring(1);

                        //logger.Debug("fileName=" + fileName);

                        //
                        //error = saveUploadedFile(uploadPath, fileName, file);
                        ////ViewBag.Message = error;
                        //if (error.Length > 0)
                        //{
                        //    ModelState.AddModelError("", error);
                        //    throw new Exception(error);
                        //}
                        
                        //PatientMedicalRecord ur = new PatientMedicalRecord();

                        //ur.PatientProfileID = GetCurrentPatientProfileID();
                        ////ur.DateReceived = uploadedRecord.DateReceived;
                        ////ur.HospitalReceived = uploadedRecord.Hospital;
                        ////ur.PatientNotes = uploadedRecord.UserNotes;
                        //ur.FileType = fileName;
                        //ur.FileName = fileType;
                        //ur.IsUploadedByUser = true;
                        //ur.InternalCode = "";
                        //ur.UploadDate = DateTime.Now;
                        //ur.FileLocation = System.IO.Path.Combine(uploadPath, fileName);
                        ////
                        //db.PatientMedicalRecords.Add(ur);
                        ////db.SaveChanges();
                        //
                        //return PartialView("_UploadSuccessful");
                       return Json("success");
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
            logger.Debug("uploadedRecord, error=" + error);
            //return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, error);
            //return PartialView("_UploadMedicalRecordTab", uploadedRecord);
            //return PartialView("_UploadFailed");
            return Json("failed");
        }

        /// <summary>
        /// PRIVATE CLASSES
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
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

        public ActionResult GetUnuploadedMedicalRecords()
        {
            int diseaseId = GetCurrentDiseaseID();
            int patientProfileId = GetCurrentPatientProfileID();
            SelectList unuploaded = MedicalRecordManager.Instance.GetUnuploadedMedicalRecordsSelectList(patientProfileId, diseaseId);
            return PartialView("_UnuploadedRecordsDropdown", unuploaded);
        }
    }
}