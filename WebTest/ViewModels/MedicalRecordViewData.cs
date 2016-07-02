using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using GlobalResources;
using System.Drawing;

namespace WebTest.ViewModels
{
    public class ImageViewData
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ThumbnailPath { get; set; }
        //public Bitmap thumbnail { get; set; }
        //public Bitmap thumbnail { get; set; }
    }

    //medical record
    public class UploadMedicalRecordViewData
    {
        public MedicalRecordViewData RecordToUpload { get; set; }
        public IEnumerable<RequiredMedicalRecordViewData> RequiredMedicalRecords { get; set; }
        public IEnumerable<UploadedMedicalRecordViewData> RecordsUploaded { get; set; }
    }

    //medical record
    public class RequiredMedicalRecordViewData
    {
        public int RecordID { get; set; }
        public string RecordName { get; set; }
        public string RecordDesc { get; set; }
        public bool IsMandatory { get; set; }
        //public bool HasBeenUploaded { get; set; }

    }
    //medical record
    public class UploadedMedicalRecordViewData
    {
        public int RecordID { get; set; }
        public string RecordName { get; set; }
        public string FileName { get; set; }
    }

    //medical record
    //public class MedicalRecordViewData
    //{
    //    public int RecordID { get; set; }

    //    [Display(Name = "Test/Procedure")]
    //    public string RecordName { get; set; }

    //    [Display(Name = "Date Received:")]
    //    public string DateReceived { get; set; }

    //    [Display(Name = "Issuing Hospital:")]
    //    public string Hospital { get; set; }

    //    //[Display(Name = "Reason:")]
    //    //[DataType(DataType.MultilineText)]
    //    //public string UserNotes { get; set; }

    //    [Display(Name = "File to Upload")]
    //    public HttpPostedFileBase RecordInput { get; set; }
    //}

    public class MedicalRecordViewData
    {
        [Display(Name = "Record Name")]
        public int RecordID { get; set; }

        public string RecordName { get; set; }

        [Display(Name = "Date Received:")]
        public string DateReceived { get; set; }

        [Display(Name = "Issuing Hospital:")]
        public string IssuingHospital { get; set; }

        [Display(Name = "File to Upload")]
        //public HttpPostedFileBase RecordInput { get; set; }
        public List<HttpPostedFileBase> RecordFiles { get; set; }
    }
}