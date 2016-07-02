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
    public class ServiceManagerViewData
    {
        public SelectList AvailablePatientProfiles { get; set; }
        //public IEnumerable<RequestedService> RequestedServices { get; set; }
        public SelectList AvailableProviders { get; set; }
        public PatientProfile CurrentPatientProfile { get; set; }
        public IEnumerable<PatientQuestion> PatientQuerstions { get; set; }
        public IEnumerable<PatientDiseaseHistoryViewData> DiseaseHistories { get; set; }
        public IEnumerable<PatientSurgicalHistoryViewData> SurgicalHistories { get; set; }
        public IEnumerable<SystemReviewViewData> SystemReviews { get; set; }
        public IEnumerable<RequiredMedicalRecordViewData> MedicalRecords { get; set; }
        public IEnumerable<PatientFamilyDiseaseHistoryViewData> FamilyHistories { get; set; }
        public PatientSocialHistory SocialHistory { get; set; }
    }
    
  





}