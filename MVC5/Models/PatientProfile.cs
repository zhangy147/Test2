using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace MVC5.Models
{
    public enum Gender
    {
        Female = 1, Male = 2
    }

    public enum EthnicGroup
    {
        White = 1, Black = 2, Asian = 3,  NativeAmerican = 4, Hispanic = 5
    }
    public enum ExerciseLevel
    {
        Sedentary, Moderate, Virorous
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
    public enum SubstanceType
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
    //
    //public class CancerProcedurePurpose
    //{
    //    public int CancerProcedurePurposeID { get; set; }
    //    public int CancerProcedureID { get; set; }
    //    public ClinicalPhase ClinicalPhase { get; set; }
    //    public ProcedurePurpose UsedFor { get; set; }
    //    //
    //    public virtual CancerProcedure CancerProcedure { get; set; }
    //}
    ////
    //public class ClinicalEvaluation
    //{
    //    public int ClinicalEvaluationID { get; set; }
    //    //public int DiseaseID { get; set; }
    //    public string Desc { get; set; }
    //    public ICollection<Procedure> RecommendedProcedures { get; set; }
    //}

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



    //public enum TreatmentGoal
    //{
    //    Primary, Adjuvant, Newadjuvant, Staging, Addtional, Local, Monitoring
    //}


    //public class PatientProfile
    //{
    //    [Key]
    //    public int PatientProfileID { get; set; }

    //    public int? UserID { get; set; }

    //    [Display(Name = "Age", ResourceType = typeof(Resources.Resources))]
    //    [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "AgeRequired")]
    //    [Range(0, 130, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "AgeRange")]
    //    public int Age { get; set; }

    //    [Display(Name = "Gender", ResourceType = typeof(Resources.Resources))]
    //    [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GenderRequired")]
    //    public Gender? Gender { get; set; }

    //    public int? DiseaseID { get; set; }
    //    public virtual Cancer Cancer { get; set; }

    //    public string InitialStageCode { get; set; }
    //    public virtual Stage InitialStage { get; set; }
    //    public string FinalStageCode { get; set; }
    //    public virtual Stage FinalStage { get; set; }
    //    //
    //    public virtual ICollection<Procedure> ProceduresDone { get; set; }
    //    public virtual ICollection<TreatmentIndication> TreatmentIndications { get; set; }

    //    public DateTime InsertDate { get; set; }
    //    public DateTime UpdateDate { get; set; }
    //}


    public class PatientProfile
    {
        public int PatientProfileID { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRequired")]
        [Range(1, 130, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRange")]
        public int Age { get; set; }

        [Display(Name = "Sex")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "GenderRequired")]
        public Gender Gender { get; set; }

        [Display(Name = "Ethnic Group")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EthnicGroupRequired")]
        public EthnicGroup Ethnic { get; set; }

        [Display(Name = "Disease")]
        public int? DiseaseID { get; set; }
        public virtual Disease Disease { get; set; }
        //
        [Display(Name = "Year and Month of Diagnosis")]
        public DateTime? DateDiagnosed { get; set; }
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
        public virtual ICollection<Procedure> ReceivedProcedures { get; set; }

        public virtual ICollection<Note> PhysicianNotes { get; set; }
        public virtual ICollection<PatientMedicalRecord> PatientMedicalRecords { get; set; }
        public PatientSocialHistory SocialHistory { get; set; }
        public virtual ICollection<PatientFamilyMedicalHistory> PatientFamilyMedicalHistories { get; set; }
        public virtual ICollection<RequestedService> RequestedServices { get; set; }
        public virtual ICollection<PatientQuestion> PatientQuestions { get; set; }
        //public virtual ICollection<SuggestedReading> SuggestedReadings { get; set; }
        public virtual ICollection<Note> PatientNotes { get; set; }
    }


    public class PatientMedicalHistory
    {
        public int PatientMedicalHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiseaseID { get; set; }
        public bool IsPositive { get; set; }
        public string PatientSuppliedCondition { get; set; }
        public string PatientNote { get; set; }
    }
    public class PatientSurgicalHistory
    {
        public int PatientSurgicalHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int TreatmentID { get; set; }
        public bool PatientReplied { get; set; }
        public DateTime DatePerformed { get; set; }
        public string PatientSuppliedCondition { get; set; }
        public string PatientNote { get; set; }
    }
    public class PatientSystemReview
    {
        public int PatientSystemReviewID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiagnosticFactorID { get; set; }
        public bool PatientReplied { get; set; }
        public string PatientSuppliedCondition { get; set; }
        public string Note { get; set; }
    }

    public class PatientFamilyMedicalHistory
    {
        public int PatientFamilyMedicalHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiseaseID { get; set; }
        public FamilyMember FamilyMember { get; set; }
        public string PatientNote { get; set; }
    }
    //
    public class PatientSocialHistory
    {
        public int PatientSocialHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public virtual ICollection<SubstanceUse> SubstanceUses { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public ExerciseLevel ExerciseLevel { get; set; }
        public string CurrentJob { get; set; }
        public bool WasPhysicallyAbused { get; set; }
        public bool WasMentallyAbused { get; set; }
        public bool IsDisabled { get; set; }
    }
    //
    public class Antigen
    {
        public int AntigenID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
    //
    public class AllergyReaction
    {
        public int AllergyReactionID { get; set; }
        public int AntigenID { get; set; }
        public string Reaction { get; set; }
        public bool IsPatientDescribed { get; set; }
    }
    //
    public class PatientAllergyHistory
    {
        public int PatientAllergyHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public virtual ICollection<AllergyReaction> AllergyReactions { get; set; }
    }
    //
    public class PatientDrugHistory
    {
        public int PatientDrugHistoryID { get; set; }
        public int PatientProfileID { get; set; }
        public int DrugID { get; set; }
        public string Dose { get; set; }
        public string HowOftenTaken { get; set; }
        public int HowLongTakenInMonth { get; set; }
        public string PatientDescribedReaction { get; set; }
    }

    //
    public class SubstanceUse
    {
        public int SubstanceUseID { get; set; }
        public SubstanceType Type { get; set; }
        public string Name { get; set; }
        public bool IsCurrentInUse { get; set; }
        //public bool IsPastInUse { get; set; }
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
        public int DiseaseGroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public ICollection<Disease> Diseases { get; set; }
    }
    public class DiseaseSpecificQuestion
    {
        public int DiseaseSpecificQuestionID { get; set; }
        public int DiseaseGroupID { get; set; }
        public string SpecificQuestion { get; set; }
        //public string[] PossibleAnswers { get; set; }
    }
    public class DiseaseSpecificQuestionAnswer
    {
        public int DiseaseSpecificQuestionAnswerID { get; set; }
        public int DiseaseSpecificQuestionID { get; set; }
        public string Answer { get; set; }
        public int Score { get; set; }
        public bool AllowMultiple { get; set; }
    }

    public class PatientDiseaseSpecificInformation
    {
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
        public string QuestionAsked { get; set; }
        public DateTime DateAsked { get; set; }
        //
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
        public DateTime DateAnswered { get; set; }

        public int PhysicianID { get; set; }
        [ForeignKey("PhysicianID")]
        public virtual Physician AnsweredBy { get; set; }
        public virtual ICollection<Reference> Sources { get; set; }
    }
}