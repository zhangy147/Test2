


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

using WebTest.Models;


namespace WebTest.ViewModels
{
    public class DiseaseViewData
    {
        public int DiseaseID { get; set; }

        [Display(Name = "PatientDiagnosis", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DiseaseMustBeSelected")]
        public string DiseaseName { get; set; }
        //
        [Display(Name = "PatientDiagnosedOn", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DiagnosisDateRequired")]
        public string DateDiagnosed { get; set; }
        //
        [Display(Name = "PatientDiagnosedFrom", ResourceType = typeof(Resources))]
        public string HospitalDiagnosisMade { get; set; }
    }
    //
    public class PatientViewData
    {
        [Display(Name = "PatientAge", ResourceType=typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRequired")]
        [Range(1, 130, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRange")]
        public int Age { get; set; }

        [Display(Name = "PatientSex", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "GenderRequired")]
        public string Gender { get; set; }

        [Display(Name = "PatientEthnicGroup", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EthnicGroupRequired")]
        public string Ethnic { get; set; }

        [Display(Name = "PatientMainConcerns", ResourceType = typeof(Resources))]
        [DataType(DataType.MultilineText)]
        public string Concerns { get; set; }
        //
        [Display(Name = "PatientGoals", ResourceType = typeof(Resources))]
        [DataType(DataType.MultilineText)]
        public string Goals { get; set; }
    }

    //
    public class DiseaseStateViewData
    {
        public IEnumerable<DiseaseTreatmentFactorViewData> txFactors { get; set; }
        public IEnumerable<DiseaseProcedureViewData> procedures { get; set; }
    }

    
    public class TreatmentConditionViewData
    {
        public int ConditionID { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
        public bool IsComposed { get; set; }
    }
    //
    public class DiseaseTreatmentFactorViewData
    {
        //public int Index { get; set; }
        public int FactorID { get; set; }
        public string Prompt { get; set; }
        public string Category { get; set; }
        public int DependentFactorID { get; set; }
        public string DependentConditionIds { get; set; }
        public int Order { get; set; }
        public bool IsLast { get; set; }
        public List<int> SelectedTreatmentConditionID { get; set; }
        public List<TreatmentConditionViewData> Conditions { get; set; }
    }

    public class PatientProfileDiseaseViewData
    {
        [Required(ErrorMessage="Must select a name from popup list")]
        public int DiseaseID { get; set; }

        [Display(Name = "We need to know the name of the disease for this service. This could be a definitve diagnosis or a most likely diagnosis that needs further confirmation. If the you have more than one diagnosis, enter the diagnosis of most concerns to you.")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DiseaseNameRequired")]
        public string DiseaseName { get; set; }

        public DateTime DateDiagnosed { get; set; }

        public string Hospital { get; set; }
    }

    public class DiseaseProcedureViewData
    {
        public int ProcedureID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsReceived { get; set; }
    }
    //
    public class PatientCaseViewData
    {

    }
}