using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;
using System.Drawing;

namespace MVC5.ViewModels
{
    public class ServiceManagerViewData
    {
        public SelectList AvailablePatientProfiles { get; set; }
        public IEnumerable<RequestedService> RequestedServices { get; set; }
        public SelectList AvailableProviders { get; set; }
        public PatientProfile CurrentPatientProfile { get; set; }
        public IEnumerable<PatientQuestion> PatientQuerstions { get; set; }
        public IEnumerable<MedicalHistoryViewData> MedicalHistories { get; set; }
        public IEnumerable<SurgicalHistoryViewData> SurgicalHistories { get; set; }
        public IEnumerable<SystemReviewViewData> SystemReviews { get; set; }
        public IEnumerable<MedicalRecordViewData> MedicalRecords { get; set; }
        public IEnumerable<FamilyHistoryViewData> FamilyHistories { get; set; }
        public SocialHistoryViewData SocialHistory { get; set; }
    }
    //
    public class ServiceViewData
    {
        [Required]
        [Display(Name = "Servie")]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }

        public bool IsRequested { get; set; }
        public bool AllowChooseProvider { get; set; }

        [Required]
        [Display(Name = "Provider")]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }

        //public SelectList AvailableProviders { get; set; }
    }

    public class ImageViewData
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ThumbnailPath { get; set; }
        //public Bitmap thumbnail { get; set; }
        //public Bitmap thumbnail { get; set; }
    }

    public class UploadRecordViewData
    {
        public int RecordID { get; set; }

        [Display(Name = "Test/Procedure")]
        public string RecordName { get; set; }

        [Display(Name = "Record Type")]
        public string RecordType { get; set; }

        [Display(Name = "Date:")]
        public DateTime DatePerformed { get; set; }

        [Display(Name = "Hospital:")]
        public string HospitalPerformed { get; set; }

        [Display(Name = "Reason:")]
        [DataType(DataType.MultilineText)]
        public string UserNotes { get; set; }


        [Display(Name = "File to Upload")]
        public HttpPostedFileBase File { get; set; }
    }

    public class MedicalRecordViewData
    {
        public int MedicalRecordID { get; set; }
        public string RecordName { get; set; }
        public string RecordDesc { get; set; }
        public bool Uploaded { get; set; }

        public string FileName { get; set; }
    }

    public class MedicalHistoryViewData
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class SurgicalHistoryViewData
    {
        public int TreatmentID { get; set; }
        public string SurgeryName { get; set; }
        public DateTime DatePeformwd { get; set; }
        public bool IsSelected { get; set; }
    }

    public class SystemReviewViewData
    {
        public string SystemName { get; set; }
        public List<SymptomReviewViewData> SymptomReviewViewDataList { get; set; }
    }
    public class SymptomReviewViewData
    {
        public int DiagnosticFactorID { get; set; }
        public string SymtomName { get; set; }
        public bool IsSelected { get; set; }
    }

    //=============================================
    // Other history: family and social
    //=============================================
    public class FamilyHistoryViewData
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public bool IsInflicted { get; set; }
        public List<string> FamilyMembers { get; set; }
        public List<string> InflictingMembers { get; set; }
    }
    public class SocialHistoryViewData
    {
        public PatientSocialHistory SocialHistory { get; set; }
        public List<string> SubstanceTypeList { get; set; }
        public List<string> MaritalStatusList { get; set; }
        public List<string> EmploymentStatusList { get; set; }
        public List<string> ExerciseLevelList { get; set; }
    }
}