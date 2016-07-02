using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using WebTest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest.ViewModels
{
    public class MedicalHistoryViewData
    {
        public SelectList AvailablePatientProfiles { get; set; }

        public PatientProfile CurrentPatientProfile { get; set; }
       
        public List<PatientDiseaseHistoryViewData> DiseaseHistories { get; set; }
        public List<PatientSurgicalHistoryViewData> SurgicalHistories { get; set; }
        public List<SystemReviewViewData> SystemReviews { get; set; }
       
        public PatientFamilyDiseaseHistoryViewData FamilyHistories { get; set; }
        public PatientSocialHistory SocialHistory { get; set; }
    }
    //
    //============================================================
    // Medical History
    //============================================================
    //
    public class PatientMedicalConditionHistoryViewData
    {

        public string BodySystemName { get; set; }
        public string BodySystemTooltip { get; set; }
        public List<MedicalConditionHistoryViewData> MedicalConditionHistories { get; set; }
    }

    public class MedicalConditionHistoryViewData
    {
        public int RequiredMedicalConditionHistoryID { get; set; }
        public string MedicalCondition { get; set; }
        public bool IsSelected { get; set; }
    }
    public class PatientDiseaseHistoryViewData
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public bool IsSelected { get; set; }
    }
    public class PatientSurgicalHistoryViewData
    {
        public int TreatmentID { get; set; }
        public string SurgeryName { get; set; }
        public DateTime DatePeformwd { get; set; }
        public bool IsSelected { get; set; }
    }
    //
    //==================================================
    // System review
    //==================================================
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
    // Family history
    //=============================================
    public class PatientFamilyDiseaseHistoryViewData
    {
        public int PatientProfileID { get; set; }
        public List<FamilyDiseaseHistoryViewData> FamilyDiseaseHistories { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
    }
    public class FamilyDiseaseHistoryViewData
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public List<FamilyMemberDiseaseHistoryViewData> MemberDiseaseHistories { get; set; }
    }
    public class FamilyMemberDiseaseHistoryViewData
    {
        public FamilyMember Member { get; set; }
        public bool HasDiagnosed { get; set; }
    }
    //
    //====================================================
    // Social history
    //====================================================
    public class PatientSocialHistoryViewData
    {
        public int PatientSocialHistoryID { get; set; }
        public List<PatientSubstanceUseViewData> SubstanceUses { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public ExerciseLevel ExerciseLevel { get; set; }
        public string CurrentJob { get; set; }
    }
    public class PatientSubstanceUseViewData
    {
        public Substance Substance { get; set; }
        public bool IsCurrentInUse { get; set; }
        public bool IsPastInUse { get; set; }
        public string Quantity { get; set; }
        public int LengthInYear { get; set; }
        public int StoppedInYear { get; set; }
    }
    //
  //========================================================
    //Medication & Allergy
    //========================================================
    public class PatientMedicationHistoryViewData
    {
        [Display(Name = "Medication")]
        public string DrugName { get; set; }
        [Display(Name = "Dose")]
        public string Dose { get; set; }
        [Display(Name = "How Often")]
        public string HowOften { get; set; }
        
        [Display(Name = "How Long (Month)")]
        public int HowLong { get; set; }
        [Display(Name = "Reason to Take")]
        public string Reason { get; set; }
    }
    public class PatientAllergyHistoryViewData
    {
        [Display(Name = "Medication Allergic To")]
        public string AntigenName { get; set; }  
        public bool IsMedicine { get; set; }
        [Display(Name = "Reaction")]
        public string Reaction { get; set; }
        [Display(Name = "Year Noticed")]
        public int YearDiscovered { get; set; }
    }
    //
    public class PatientMedicationAndAllergyHistoryViewData
    {
        [Display(Name = "Is patient currently taking any medications or supplements?")]
        public bool HasMedicationHistory { get; set; }
        [Display(Name = "Please list all medications and supplements(including vitamins) that patient is currenly taking.")]
        public List<PatientMedicationHistoryViewData> medicationHistories { get; set; }
        //
        [Display(Name = "Is patient allergic to any medications?")]
        public bool HasAllergyHistory { get; set; }
        [Display(Name = "Please list all medications that patient is allergic to.")]
        public List<PatientAllergyHistoryViewData> allergyHistories { get; set; }
    }        
}