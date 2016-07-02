using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace WebTest.Models
{
    public enum TreatmentModality
    {
        Surgery, Chemotherapy, Radiation, Chemoradiation, 
        AdjuvantChemotherapy, NewAdjuvantChemotherapy, 
        AdjuvantRadiation, NewadjuvantRadiation, 
        AdjuvantChemoradiation, NewadjuvantChemoradiation, 
        TargetTherapy, DrugTherapy, BehavioralTherapy, LaserTherapy,
        SupportiveCare, Observation
    }
    public enum CancerTreatmentPhase
    {
        initial, additional, firstline, secondline, thirdline, maintenance, recurrence, primary, paralell
    }
    public enum TreatmentGoal
    {
        Diagnositic, Palliative, Curative, Preventive, ProlongSurvival, None
    }
    public class SideEffect
    {
        [Key]
        public int SideEffectID { get; set; }
        public string Effect { get; set; }
        public string Desc { get; set; }
        public bool IsTreatable { get; set; }
        public bool IsCurable { get; set; }
    }

    public class DrugCategory
    {
        [Key]
        public int DrugCategoryID { get; set; }
        public string Category { get; set; }
        public string Desc { get; set; }
        public int PartentCategroyID { get; set; }
    }
    //
    public class Drug
    {
        [Key]
        public int DrugID { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public int DrugCategoryID { get; set; }
        public virtual DrugCategory Category { get; set; }
        public string ClinicalUse { get; set; }
        public string Note { get; set; }
        public virtual ICollection<SideEffect> SideEffects { get; set; }
    }

    public enum TreatmentFactorCategory
    {
        Diagnostic, DiseaseDynamicState, DiseaseStaticState, TreatmentFeasibility, PatientFeasibility, PostTreatmentEvaluation, OtherSupport
    }

    public class TreatmentFactor
    {
        [Key]
        public int TreatmentFactorID { get; set; }
        public string FactorName { get; set; }
        public TreatmentFactorCategory FactorCategory { get; set; }
        //public bool IsFromPatientPerspective { get; set; }
        public bool AllowMultipleValues { get; set; }
        public string PatientPrompt { get; set; }
        //
        public virtual ICollection<TreatmentCondition> TreatmentConditions { get; set; }
    }
    //
    public class TreatmentCondition
    {
        [Key]
        public int TreatmentConditionID { get; set; }
        public int TreatmentFactorID { get; set; }
        public string FactorValue { get; set; }
        public int Order { get; set; }
        public bool IsComposed { get; set; }
        public string Note { get; set; }

        public virtual TreatmentFactor TreatmentFactor { get; set; }
    }
    //
    // this should be a view table
    public class DiseaseTreatmentFactor
    {
        [Key]
        public int DiseaseTreatmentFactorID { get; set; }
        public int DiseaseID { get; set; }
        public int TreatmentFactorID { get; set; }
        public bool HasComposedValue { get; set; }
        //public bool IsIndependent { get; set; }
        public int DependentFactorID { get; set; }
        public string DependentConditionID { get; set; }
        //public bool IsExclusive { get; set; }
        //public bool AskedAlways { get; set; }
        public int Order { get; set; }
        //
        public virtual TreatmentFactor TreatmentFactor { get; set; } 
    }


    //
    //design is similar to TreatmentFactor => TreatmentCondition
    public class DiseaseTreatmentIndication
    {
        [Key]
        public int DiseaseTreatmentIndicationID { get; set; }
        public int DiseaseID { get; set; }
        public string Indication { get; set; }
        public int Order { get; set; }
        //
        public virtual ICollection<IndicatedTreatmentCondition> TreatmentConditions { get; set; }
        public virtual ICollection<DiseaseTreatmentPlan> DiseaseTreatmentPlans { get; set; }
    }
    //
    public class IndicatedTreatmentCondition
    {
        [Key]
        public int IndicatedTreatmentConditionID { get; set; }
        public int DiseaseTreatmentIndicationID { get; set; }
        public int TreatmentConditionID { get; set; }
        public int Order { get; set; }
        //
        public virtual TreatmentCondition TreatmentCondition { get; set; }
        public virtual DiseaseTreatmentIndication DiseaseTreatmentIndication { get; set; }
    }
    //
    //public class DiseaseTreatmentFactor
    //{
    //    public int DiseaseTreatmentFactorID { get; set; }
    //    public int DiseaseID { get; set; }
    //    //public string StageCode { get; set; }
    //    public int TreatmentFactorID { get; set; }
    //    public int SortOrder { get; set; }

    //    public virtual Disease Disease { get; set; }
    //    public virtual TreatmentFactor TreatmentFactor { get; set; }
    //    //
    //    //public virtual ICollection<TreatmentIndication> TreatmentIndications { get; set; }
    //}


    //this is for individual treatment
    public class Treatment
    {
        [Key]
        public int TreatmentID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public TreatmentModality Modality { get; set; }
    }
    //
    //this is for combination of/or individual treatment
    public class TreatmentPlan
    {
        [Key]
        public int TreatmentPlanID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Note { get; set; }
        //
        //this is reserved for future use
        public ICollection<Treatment> Treatments { get; set; }
    }
    //
    public class DiseaseTreatmentPlan
    {
        [Key]
        public int DiseaseTreatmentPlanID { get; set; }
        public int DiseaseTreatmentIndicationID { get; set; }
        public string TargetCondition { get; set; }
        public int TreatmentPlanID { get; set; }
        public int TreatmentPlanPreferrence { get; set; }
        public string NCCNCategory { get; set; }
        //
        public virtual DiseaseTreatmentIndication DiseaseTreatmentIndication { get; set; }
    }

    //
    //public class TreatmentOption
    //{
    //    [Key]
    //    public int TreatmentOptionID { get; set; }
    //    public string Option { get; set; }
    //    public string Desc { get; set; }
    //    public CancerTreatmentPhase TreatmentPhase { get; set; }
    //    public TreatmentGoal TreatmentGoal { get; set; }
    //    public string Cancer { get; set; }
    //    public virtual ICollection<TreatmentNote> TreatmentNotes { get; set; }
    //    //
    //    public virtual ICollection<DiseaseTreatmentIndication> Indications { get; set; }
    //    public virtual ICollection<Treatment> Treatments { get; set; }
    //    //
    //    public virtual ICollection<Trail> Trails { get; set; }
    //}
    //public class CancerTreatmentPlan
    //{
    //    [Key]
    //    public int CancerTreatmentPlanID { get; set; }
    //    public string PlanName { get; set; }
    //    public string PlanDesc { get; set; }
    //    public int? DiseaseID { get; set; }
    //    public string StageCode { get; set; }
    //    public TreatmentGoal TreatmentGoal { get; set; }
    //    public string NotesForPatient { get; set; }
    //    public int DisplaySequenceNo { get; set; }
    //    //
    //    public virtual ICollection<DiseaseTreatmentIndication> Indications { get; set; }
    //    public virtual ICollection<TreatmentOption> InitialTreatmentOptions { get; set; }
    //    public virtual ICollection<TreatmentOption> AdditionalTreatmentOptions { get; set; }
    //    //
    //    public virtual ICollection<Study> SupportingStudies { get; set; }
    //    //
    //    public virtual Cancer Cancer { get; set; }
    //    public virtual Stage Stage { get; set; }
    //}

}