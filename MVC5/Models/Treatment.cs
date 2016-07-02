using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace MVC5.Models
{
    public enum TreatmentModality
    {
        Surgery, Chemotherapy, Radiation, Chemoradiation, Targettherapy, Medicine, None, Undefined
    }
    public enum TreatmentPhase
    {
        initial, additional, firstline, secondline, thirdline, maintenance, recurrence, primary, paralell
    }
    public enum TreatmentGoal
    {
        Diagnositic, Palliative, Curative, Preventive, ProlongSurvival, None
    }
    public class SideEffect
    {
        public int SideEffectID { get; set; }
        public string Effect { get; set; }
        public string Desc { get; set; }
        public bool IsTreatable { get; set; }
        public bool IsCurable { get; set; }
    }

    public class DrugCategory
    {
        public int DrugCategoryID { get; set; }
        public string Category { get; set; }
        public string Desc { get; set; }
        public int PartentCategroyID { get; set; }
    }
    //
    public class Drug
    {
        public int DrugID { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public int DrugCategoryID { get; set; }
        public virtual DrugCategory Category { get; set; }
        public string ClinicalUse { get; set; }
        public string Note { get; set; }
        public virtual ICollection<SideEffect> SideEffects { get; set; }
    }
    //public class FactorValue
    //{
    //    public int FactorValueID { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public string Value { get; set; }

    //    public virtual ICollection<DecisionCondition> DecisionConditions { get; set; }
    //}
    public enum TreatmentFactorType
    {
        Diagnosis, Staging, Substaging, TumorSpecial, Medical, Operation, Other
    }
    public class TreatmentFactor
    {
        public int TreatmentFactorID { get; set; }
        public string FactorName { get; set; }
        public TreatmentFactorType FactorType { get; set; }
        public string PatientPrompt { get; set; }
    }

    //
    public class DiseaseTreatmentFactor
    {
        public int DiseaseTreatmentFactorID { get; set; }
        public int? DiseaseID { get; set; }
        public string StageCode { get; set; }
        public int TreatmentFactorID { get; set; }
        public int Order { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual TreatmentFactor TreatmentFactor { get; set; }
        //
        public virtual ICollection<TreatmentIndication> TreatmentIndications { get; set; }
    }

    //new
    public class TreatmentIndication
    {
        [Key]
        public int TreatmentIndicationID { get; set; }
        public string Indication { get; set; }
        public int DiseaseTreatmentFactorID { get; set; }
        public string FactorValue { get; set; }
        public int? FactorNumericValue { get; set; }

        //public int FactorValueID { get; set; }

        [ForeignKey("DiseaseTreatmentFactorID")]
        public virtual DiseaseTreatmentFactor DiseaseTreatmentFactor { get; set; }
        //[ForeignKey("FactorValueID")]
        //public virtual FactorValue FactorValue { get; set; }
    }
    //
    //
    //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
    //
    public class TreatmentImplementation
    {
        public int TreatmentImplementationID { get; set; }
        public string Method { get; set; }
        public bool IsChemotherapy { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
    }

    //
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string Name { get; set; }
        public string Implementation { get; set; }
        public TreatmentModality Modality { get; set; }
        public string Note { get; set; }
        public bool UsedForPMH { get; set; }
    }
    //
    //type: note4patient, note4professional, advantage, disadvantage
    public class TreatmentNote
    {
        public int TreatmentNoteID { get; set; }
        public int TreatmentOptionNote { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public int DisplayOrder { get; set; }
    }
    //
    //
    public class TreatmentOption
    {
        public int TreatmentOptionID { get; set; }
        public string Option { get; set; }
        public string Desc { get; set; }
        public TreatmentPhase TreatmentPhase { get; set; }
        public TreatmentGoal TreatmentGoal { get; set; }
        public string Cancer { get; set; }
        public virtual ICollection<TreatmentNote> TreatmentNotes { get; set; }
        //
        public virtual ICollection<TreatmentIndication> Indications { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
        //
        public virtual ICollection<Trail> Trails { get; set; }
    }
    public class CancerTreatmentPlan
    {
        public int CancerTreatmentPlanID { get; set; }
        public string PlanName { get; set; }
        public string PlanDesc { get; set; }
        public int? DiseaseID { get; set; }
        public string StageCode { get; set; }
        public TreatmentGoal TreatmentGoal { get; set; }
        public string NotesForPatient { get; set; }
        public int DisplaySequenceNo { get; set; }
        //
        public virtual ICollection<TreatmentIndication> Indications { get; set; }
        public virtual ICollection<TreatmentOption> InitialTreatmentOptions { get; set; }
        public virtual ICollection<TreatmentOption> AdditionalTreatmentOptions { get; set; }
        //
        public virtual ICollection<Study> SupportingStudies { get; set; }
        //
        public virtual Cancer Cancer { get; set; }
        public virtual Stage Stage { get; set; }
    }

}