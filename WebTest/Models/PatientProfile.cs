using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace WebTest.Models
{
    public enum Gender
    {
        Female = 1, Male = 2
    }
    public enum EthnicGroup
    {
        White = 1, Black = 2, Asian = 3, NativeAmerican = 4, Hispanic = 5
    }
    public enum ExerciseLevel
    {
        Sedentary, Moderate, Vigorous
    }
    public enum MaritalStatus
    {
        Married, Divorced, Single, Widow
    }
    public enum EmploymentStatus
    {
        Employed, Retired, Unemployed, Selfemployed
    }
    public enum FamilyMember
    {
        Grandparents = 1, Father = 2, Mother = 3, Brother = 4, Sister = 5, Son = 6, Daughter = 7, None = 8
    }
    public enum Substance
    {
        Tabacco, Alcohol, Drug, Other
    }
    public enum ClinicalPhase
    {
        inital_diagnosis, confirming_diagnosis, pretreatment_evaluation, under_treatment, post_treatment
    }
    //
    public enum ProcedurePurpose
    {
        detecting, confirming, staging, patient_evaluation, effect_evaluation, survillence
    }

    public class AdvisingAuthority
    {
        [Key]
        public int AuthorityID { get; set; }
        public string Name { get; set; }
        public string SiteUrl { get; set; }
        public string Introduction { get; set; }
        public string SupportPhoneNo { get; set; }

        //public virtual ICollection<TreatmentDecisionDetail> TreatmentDecisionDetails { get; set; }
    }

    public class PatientProfile
    {
        [Key]
        public int PatientProfileID { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRequired")]
        [Range(1, 130, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRange")]
        public int Age { get; set; }

        [Display(Name = "Sex")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "GenderRequired")]
        public string Gender { get; set; }

        [Display(Name = "Ethnic Group")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EthnicGroupRequired")]
        public string Ethnic { get; set; }

        [Display(Name = "Disease")]
        public int? DiseaseID { get; set; }
        public virtual Disease Disease { get; set; }
        //
        [Display(Name = "Year and Month of Diagnosis")]
        public string DateDiagnosed { get; set; }
        //
        [Display(Name = "Hospital")]
        public string HospitalDiagnosisMade { get; set; }
        //
        [Display(Name = "Main Concerns")]
        [DataType(DataType.MultilineText)]
        public string Concerns { get; set; }
        //
        [Display(Name = "Your Goals")]
        [DataType(DataType.MultilineText)]
        public string Goals { get; set; }
        //
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        //
        //information about current disease
        public virtual ICollection<PatientReceivedProcedure> ReceivedProcedures { get; set; }
        public virtual ICollection<PatientTreatmentCondition> TreatmentConditions { get; set; }
        //
        //information about patient medical history
        public virtual ICollection<PatientMedicalConditionHistory> MedicalConditionHistories { get; set; }
        public virtual ICollection<PatientDiseaseHistory> DiseaseHistories { get; set; }
        public virtual ICollection<PatientSurgicalHistory> SurgicalHistories { get; set; }
        public virtual ICollection<PatientSystemReview> SystemReviews { get; set; }
        public PatientSocialHistory SocialHistory { get; set; }
        public virtual ICollection<PatientFamilyDiseaseHistory> FamilyDiseaseHistories { get; set; }
        //
        //information about patient medica records
        public virtual ICollection<PatientMedicalRecord> MedicalRecords { get; set; }
        //
        //information about others services
        
        public virtual ICollection<Note> PhysicianNotes { get; set; }
        public virtual ICollection<PatientQuestion> PatientQuestions { get; set; }
        //public virtual ICollection<SuggestedReading> SuggestedReadings { get; set; }
        public virtual ICollection<Note> PatientNotes { get; set; }
        //
        
    }

    public class PatientReceivedProcedure
    {
        [Key]
        public int PatientReceivedProcedureID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiseaseProcedureID { get; set; }
    }

    //
    public class PatientTreatmentCondition
    {
        [Key]
        public int PatientTreatmentConditionID { get; set; }
        public int PatientProfileID { get; set; }
        public int TreatmentConditionID { get; set; }
        //public DateTime InsertDate { get; set; }
        //public DateTime UpdateDate { get; set; }
    }
    //one disease may be assigned to multiple specialiaties  
    //one specialty may see multiple dieases
    public class DiseaseAssignment
    {
        [Key]
        public int DiseaseAssignmentID { get; set; }
        public int DiseaseID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class RequiredMedicalConditionHistory
    {
        [Key]
        public int RequiredMedicalConditionHistoryID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public int PhysicianGroupID { get; set; }
        public int BodySystemID { get; set; }
        public string MedicalCondition { get; set; }
        //
        public virtual BodySystem BodySystem { get; set; }
        public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    }
 
    //one specialty has more diseases to collect
    public class RequiredDiseaseHistory
    {
        [Key]
        public int RequiredDiseaseHistoryID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public int UserGroupID { get; set; }
        public int DiseaseID { get; set; }
        //
        public virtual Disease Disease { get; set; }
        public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    }
    public class RequiredSurgicalHistory
    {
        [Key]
        public int RequiredSurgicalHistoryID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public int UserGroupID { get; set; }
        public int TreatmentID { get; set; }
        //
        public virtual Treatment Treatment { get; set; }
        public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    }
    public class RequiredSystemReview
    {
        [Key]
        public int RequiredSystemReviewID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public int UserGroupID { get; set; }
        public int DiagnosticFactorID { get; set; }
        //
        public virtual DiagnosticFactor DiagnosticFactor { get; set; }
    }
    //
    public class RequiredFamilyDiseaseHistory 
    {
        [Key]
        public int RequiredFamilyDiseaseHistoryID { get; set; }
        public int MedicalSpecialtyID { get; set; }
        public int UserGroupID { get; set; }
        public int DiseaseID { get; set; }
        //
        public virtual Disease Disease { get; set; }
        public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    }

    public class PatientMedicalConditionHistory
    {
        [Key]
        public int PatientMedicalConditionHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredMedicalConditionHistoryID { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public string PatientNote { get; set; }
        //
        public virtual RequiredMedicalConditionHistory RequiredMedicalConditionHistory { get; set; }
    }
    public class PatientDiseaseHistory
    {
        [Key]
        public int PatientDiseaseHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredDiseaseHistoryID { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public string PatientNote { get; set; }
        public virtual RequiredDiseaseHistory RequiredDiseaseHistory { get; set; }
    }
    public class PatientSurgicalHistory
    {
        [Key]
        public int PatientSurgicalHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredSurgicalHistoryID { get; set; }
        public DateTime DatePerformed { get; set; }
        public string PatientNote { get; set; }
        public virtual RequiredSurgicalHistory RequiredSurgicalHistory { get; set; }
    }
    public class PatientSystemReview
    {
        [Key]
        public int PatientSystemReviewID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredSystemReviewID { get; set; }
        public string PatientNote { get; set; }
        //
        public virtual RequiredSystemReview RequiredSystemReview { get; set; }
    }

    public class PatientFamilyDiseaseHistory
    {
        [Key]
        public int PatientFamilyDiseaseHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredFamilyDiseaseHistoryID { get; set; }
        public FamilyMember FamilyMember { get; set; }
        public string PatientNote { get; set; }
        //
        public virtual RequiredFamilyDiseaseHistory RequiredFamilyDiseaseHistory { get; set; }
    }
    //
    public class PatientSocialHistory
    {
        public int PatientSocialHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public virtual ICollection<PatientSubstanceUse> SubstanceUses { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public ExerciseLevel ExerciseLevel { get; set; }
        public string CurrentJob { get; set; }
        public bool WasPhysicallyAbused { get; set; }
        public bool WasMentallyAbused { get; set; }
        public bool IsDisabled { get; set; }
    }
    //
    //public class Antigen
    //{
    //    [Key]
    //    public int AntigenID { get; set; }
    //    public string Name { get; set; }
    //    public string Desc { get; set; }
    //}
    ////
    //public class AllergyReaction
    //{
    //    [Key]
    //    public int AllergyReactionID { get; set; }
    //    public int AntigenID { get; set; }
    //    public string AntigenName { get; set; }  /*we cannot list all antigens, allow patient enter*/
    //    public string Reaction { get; set; }
    //    public int YearDiscovered { get; set; }
    //    public bool IsPatientDescribed { get; set; }
    //}
    //
    public class PatientAllergyHistory
    {
        [Key]
        public int PatientAllergyHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public string AntigenName { get; set; }  /*we cannot list all antigens, allow patient enter*/
        public bool IsMedicine { get; set; }
        public string Reaction { get; set; }
        public int YearDiscovered { get; set; }
    }
    //
    //public class RequiredDrugHistory
    //{
    //    [Key]
    //    public int RequiredDrugHistoryID { get; set; }
    //    public int UserGroupID { get; set; }
    //    public int MedicalSpecialtyID { get; set; }
    //    public int DrugID { get; set; }
    //}
    //
    public class PatientMedicationHistory
    {
        [Key]
        public int PatientMedicationHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int DrugID { get; set; }
        public string DrugName { get; set; }
        public string Dose { get; set; }
        public string HowOftenTaken { get; set; }
        public int HowLongTakenInMonth { get; set; }
        public string ReasonToTake { get; set; }
    }

    //
    public class PatientSubstanceUse
    {
        [Key]
        public int PatientSubstanceUseID { get; set; }
        public Substance Substance { get; set; }
        public bool IsCurrentInUse { get; set; }
        public bool IsPastInUse { get; set; }
        public string Quantity { get; set; }
        public int LengthInYear { get; set; }
        public int StoppedInYear { get; set; }
    }
    //
    public class Note
    {
        [Key]
        public int NoteID { get; set; }
        public string Content { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string Source { get; set; }
    }
    //
    public class PhysicianNote
    {
        [Key]
        public int PhysicianNoteID { get; set; }
        public int NoteID { get; set; }
        public int PhysicianID { get; set; }
    }
    //
    //
    //
    //
    //I am trying to figure out a way to present unique information for specific of disease
    //problem ====> how to  use the existing class such as Stage??
    public class DiseaseGroup
    {
        [Key]
        public int DiseaseGroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public ICollection<Disease> Diseases { get; set; }
    }
    public class DiseaseSpecificQuestion
    {
        [Key]
        public int DiseaseSpecificQuestionID { get; set; }
        public int DiseaseGroupID { get; set; }
        public string SpecificQuestion { get; set; }
        //public string[] PossibleAnswers { get; set; }
    }
    public class DiseaseSpecificQuestionAnswer
    {
        [Key]
        public int DiseaseSpecificQuestionAnswerID { get; set; }
        public int DiseaseSpecificQuestionID { get; set; }
        public string Answer { get; set; }
        public int Score { get; set; }
        public bool AllowMultiple { get; set; }
    }

    public class PatientDiseaseSpecificInformation
    {
        [Key]
        public int PatientDiseaseSpecificInformationID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiseaseSpecificQuestionID { get; set; }
        public int DiseaseSpecificQuestionAnswerID { get; set; }
    }

    public class Physician
    {
        [Key]
        public int PhysicianID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PictureLink { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        //
        public string Specialty { get; set; }
        public string FocusArea { get; set; }
        public string MedicalSchool { get; set; }
        public int GraduationYear { get; set; }
        public string ResidenceTraining { get; set; }
        public string OtherEnducation { get; set; }
        //
        public string Hornors { get; set; }
        public virtual ICollection<Reference> Publications { get; set; }
        //
        public string GroupAffiliation { get; set; }
        //public Address? WorkingAddress { get; set; }
    }

    public class PatientQuestion
    {
        [Key]
        public int PatientQuestionID { get; set; }

        [Required]
        public int PatientProfileID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
        public DateTime DateAsked { get; set; }
        //
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
        public DateTime DateAnswered { get; set; }

        public int AnswererID { get; set; }
        //[ForeignKey("PhysicianID")]
        //public virtual Physician AnsweredBy { get; set; }

        public int ReviewerID { get; set; }
        //[ForeignKey("PhysicianID")]
        //public virtual Physician ReviewedBy { get; set; }

        public virtual ICollection<Reference> Sources { get; set; }
    }
}