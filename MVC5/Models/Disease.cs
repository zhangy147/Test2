using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace MVC5.Models
{
    public enum Organ
    {
        Heart, Stomach, Colon, Skin, Bone, Throat, Esophagus, Gall_Bladder, Liver, Deudenum, Blood_Vessel, Muscle, Body
    }
    public class BodyPart
    {
        [Key]
        public int BodyPartID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CName { get; set; }
        public string CDesc { get; set; }
        public string ImageLink { get; set; }
        //
        public virtual ICollection<BodyPart> BodyParts { get; set; }
        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
    public class BodySystem
    {
        [Key]
        public int BodySystemID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CName { get; set; }
        public string CDesc { get; set; }
        public string ImageLink { get; set; }
        //
        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CancerTypeRequired")]
        public string Name { get; set; }
        public string OtherNames { get; set; }
        public string Abbreviation { get; set; }
        public string CName { get; set; }
        public string Desc { get; set; }
        //
        public bool UsedForPMH { get; set; }
        public bool UsedForFMH { get; set; }
        //
        public int BodySystemID { get; set; }
        public virtual BodySystem PrimaryBodySystem { get; set; }
        //
        public string Category { get; set; }
        //
        public int HarmIndex { get; set; }
        public int Treatability { get; set; }
        //
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }

    }
    //public enum BodySystem
    //{
    //    Gastrointentinal, Cardiovascular, Respiratory, Urinary, Obstetric, Gynecological, Endocrine, Dermatolory, Other
    //}


    public class Cancer : Disease
    {
        //[Key]
        //public int DiseaseID { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CancerTypeRequired")]
        //public String Name { get; set; }

        //public String ShortName { get; set; }

        //public string Description { get; set; }
        //public string ChineseName { get; set; }
        public decimal USIncidencePerHundredThousand { get; set; }
        public decimal CNIncidencePerHundredThousand { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
        public virtual ICollection<TNMDefinition> TNMDefinitions { get; set; }
        public virtual ICollection<CancerCellType> CellTypes { get; set; }
        //public virtual ICollection<Procedure> Procedures { get; set; }
        public virtual ICollection<StatRate> StatRates { get; set; }
    }

    public class StatRate
    {
        public int StatRateID { get; set; }
        public int DiseaseID { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public decimal MaleRate { get; set; }
        public decimal FemaleRate { get; set; }
        public int PopulationBase { get; set; }
        public virtual Cancer Cancer { get; set; }
    }

    public class Stage
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DiseaseIDRequired")]
        public int DiseaseID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StageCodeRequired")]
        public String StageCode { get; set; }


        public string ClinicalStage { get; set; }
        public virtual Cancer Cancer { get; set; }
        public string NotesForTreatment { get; set; }
        //
        public virtual ICollection<TNMStage> TNMStages { get; set; }
        //public virtual ICollection<TreatmentFactor> TreatmentFactors { get; set; }
        //public virtual ICollection<Study> Studies { get; set; }
        public virtual ICollection<Procedure> RequiredProcedures { get; set; }
        //public virtual ICollection<PatientProfile> PathientProfiles { get; set; }
    }



    //
    public class TNMStage
    {
        public int TNMStageID { get; set; }
        public int DiseaseID { get; set; }
        public string StageCode { get; set; }
        public string TCode { get; set; }
        public string NCode { get; set; }
        public string MCode { get; set; }
        public string IllustrationLink { get; set; }

        [Display(Name = "TNM Stage")]
        public string TNMCode
        {
            get
            {
                return TCode + NCode + MCode;
            }
        }
    }

    public class TNMDefinition
    {
        public int TNMDefinitionID { get; set; }
        public int DiseaseID { get; set; }
        public string Code { get; set; }
        public string Desc { get; set; }
        public string IllustrationLink { get; set; }
        public virtual Cancer Cancer { get; set; }
    }

    public class CancerCellType
    {
        public int CancerCellTypeID { get; set; }
        public int DiseaseID { get; set; }
        public string Type { get; set; }
        //public bool IsMajor { get; set; }
        public double Incidece { get; set; }
        public virtual Cancer Cancer { get; set; }
    }
}