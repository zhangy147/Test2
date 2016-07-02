using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest.Models
{

    //type: imaging, non-imaging (invasive vs non-invasive)
    //usedfor: initial diagnosis, confiming diagnosis, pre-treatment staging, pre-treatment patient evaluation
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        //public string UsedFor { get; set; } - in CancerProcedure??
        public bool IsImaging { get; set; }
        public bool IsInvasive { get; set; }
        public string NameOfTechnology { get; set; }
        //

        //public virtual ICollection<Stage> StagesAppliedTo { get; set; }
        //public virtual ICollection<Cancer> Cancers { get; set; }
    }

   
    //purpose: imageing (1) diagnosis (2) staging (3) monitor treatment effect (4) check recurrence
    //priority - indicate frequency to use
    //
    public class DiseaseProcedure
    {
        public int DiseaseProcedureID { get; set; }
        public int DiseaseID { get; set; }
        public int ProcedureID { get; set; }
        //
        public bool IsEssential { get; set; }
        public int PriorityToChoose { get; set; }
        public string MainPurpose { get; set; }
        //
        public virtual Disease Disease { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
    //

    //
    public enum DiagnosticFactorType
    {
        Symptom, Sign, Risk, History, Test, Other
    }
    //
    public class DiagnosticFactor
    {
        public int DiagnosticFactorID { get; set; }
        public string Name { get; set; }  //symtom, sign. risk factor, lab test, concurrent disease
        public DiagnosticFactorType Type { get; set; }
        public string Desc { get; set; }
        public string CName { get; set; }
        public string CDesc { get; set; }
        //
        public int BodySystemID { get; set; }
        public BodySystem BodySystem { get; set; }
        //
        //public virtual ICollection<Disease> Diseases { get; set; }   =>> cause cyclic reference
    }
    //
    //New ideas
    public class PatientCharacter
    {
        public int PatientCharacterID { get; set; }
        public string GeographicLocation { get; set; }
        public Gender Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string AgeGroup { get; set; }
        public string Setting { get; set; } //public, major hospital, community hospital, clinic etc.
    }
    //
    public class DiseasePrevalence
    {
        public int DiseasePrevalenceID { get; set; }
        public int DiseaseID { get; set; }
        public int PatientCharacterID { get; set; }
        public decimal MinPrevalence { get; set; }
        public decimal MaxPrevalence { get; set; }
        public decimal AssignedPrevalence { get; set; }
        public string ReferenceNote { get; set; }
        //
    }
    //
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public string Content { get; set; }
        //public int SymptomID { get; set; }
    }
    //
    public class Symptom : DiagnosticFactor
    {
        public int? BodyPartID { get; set; }
        public virtual BodyPart BodyPart { get; set; }
        //
        public virtual ICollection<Complaint> Complaints { get; set; }
    }

    //public class SystemReview
    //{
    //    public int SystemReviewID { get; set; }
    //    public int BodySystemID { get; set; }
    //    public virtual BodySystem BodySystem { get; set; }
    //    public int DiagnosticFactorID { get; set; }
    //    public virtual DiagnosticFactor symptom { get; set; }
    //}

    public class Risk : DiagnosticFactor
    {
        public string RiskType { get; set; }
        public bool IsManagible { get; set; }
    }

    //onset time: morning, noon, afternoon, evening, night 
    //onset progress: sudden or gradual
    //onset: acute, chronic, acute on chronic
    //quality/feel like: discomfort, sharp, dull, stabbing, burning, crushing, throbbing, nauseating, shooting, twisting or stretching
    //severity: 1-10, Are you ever awakened by it? 
    //location: ulq, luq,  rlq, llq, epigastric, diffuse, non-specific
    //radiation: stay, move around, move to one location
    //duration: mina, 10-mins, hrs, days, weeks, months
    //pattern: persistent or intermittent, continuous  with intermittent exacerbations
    //pattern: How often does it occur: hourly? daily? weekly? monthly?  
    //trigerring factors/relation to meal:
    //Aggravating factors: Movement, bending, lying down, walking, standing
    //Alleviating factors: Medications, massage, heat/cold, changing position, being active, resting
    //accompany alarming symptoms:
    //accompany regular symptoms:
    public class DiagnosticFactorCharacter
    {
        public int DiagnosticFactorCharacterID { get; set; }
        public int DiagnosticFactorID { get; set; }
        public string Character { get; set; }
        public string CCharacter { get; set; }
        //
        public string Prompt { get; set; }
        public string CPrompt { get; set; }
        public int OrderToPrompt { get; set; }
    }
    //
    public class DiagnosticFinding
    {
        public int DiagnosticFindingID { get; set; }
        public int DiagnosticFactorCharacterID { get; set; }
        public string Finding { get; set; }
    }
    //
    public class PatientDiagnosticFinding
    {
        public int PatientID { get; set; }
        public PatientCharacter PatientCharacter { get; set; }
        public virtual ICollection<DiagnosticFinding> Findings { get; set; }
    }

    //public class SymptomPrompt
    //{
    //    [Key]
    //    public int SymptomPromptID { get; set; }
    //    public int SeqNo { get; set; }
    //    //
    //    public int SymptomID { get; set; }
    //    public virtual Symptom Symptom {get; set;}
    //    //
    //    public string Prompt { get; set; }
    //    //
    //    public virtual ICollection<SymptomState> SymptomStates { get; set; }
    //}
    ////
    //public class SymptomState
    //{
    //    [Key]
    //    public int SymptomStateID { get; set; }
    //    public int SymptomPromptID { get; set; }
    //    public virtual SymptomPrompt SymptomPrompt {get; set;}
    //    public string State { get; set; }
    //    //
    //    public virtual ICollection<DiagnosisReply> DiagnosisReplies { get; set; }
    //}
    ////
    //public class SymptomPromptStep
    //{
    //    public int SymptomPromptStepID { get; set; }
    //    //
    //    public int? SymptomStateID { get; set; }
    //    public virtual SymptomState SymptomState {get; set;}
    //    //
    //    public int NextPromptID { get; set; }
    //    public virtual SymptomPrompt Prompt { get; set; }
    //}
    //
    //public class DiagnosisReply
    //{
    //    public int DiagnosisReplyID { get; set; }
    //    public string Reply { get; set; }

    //    public ICollection<SymptomState> SymptomStates { get; set; }
    //    public string SelfCareAdvice { get; set; }
    //}
    //
    //
    //public class DiseaseDiagnosticFactor
    //{
    //    public int DiseaseDiagnosticFactorID { get; set; }  
    //    public int DiseaseID { get; set; }
    //    public int DiagnosticFactorID { get; set; }
    //    //
    //    public virtual Disease Disease { get; set; }
    //    public virtual DiagnosticFactor DiagnosticFactor { get; set; } 
    //}
    //
    public class DiseaseDiagnosticFinding
    {
        public int DiseaseDiagnosticFindingID { get; set; }
        //
        public int DiseasePrevalenceID { get; set; }
        public virtual DiseasePrevalence DiseasePrevalence { get; set; }
        //
        public int DiseaseID { get; set; }
        public int DiagnosticFactorID { get; set; }
        //public int DiseaseDiagnosticFactorID { get; set; }
        //public virtual DiseaseDiagnosticFactor DiseaseDiagnosticFactor { get; set; }
        //
        public int DiagnosticFindingID { get; set; }
        public virtual DiagnosticFinding DiagnosticFinding { get; set; }
        //
        public int Weight { get; set; }
        //
        public decimal MinPrevalence { get; set; }
        public decimal MaxPrevalence { get; set; }
        public decimal Prevalence { get; set; }
        //
        public decimal Sensitivity { get; set; }
        public decimal Specificity { get; set; }
        //
        public decimal MinPositiveLR { get; set; }
        public decimal MaxPositiveLR { get; set; }
        public decimal PositiveLR { get; set; }
        //
        public decimal MinNegativeLR { get; set; }
        public decimal MaxNegativeLR { get; set; }
        public decimal NegativeLR { get; set; }
        //
        public string Note { get; set; }
        //
        //public virtual ICollection<Reference> References { get; set; }
    }
    //
    public class DiseaseDiagnositicRule
    {
        public int DiseaseDiagnositicRuleID { get; set; }
        public int DiseaseID { get; set; }
        public int DiseaseDiagnosticFindingID { get; set; }
        public int DiagnosticScore { get; set; }
        public string Note { get; set; }
    }

}