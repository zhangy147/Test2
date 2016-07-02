using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace WebTest.Models
{
    //=======================================================================
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string NameOnReferrence { get; set; }
    }

    //public class ReferenceAuthor
    //{
    //    public int ReferenceAuthorID { get; set; }

    //    public int ReferenceID { get; set; }
    //    public virtual Reference Reference { get; set; }

    //    public int AuthorID { get; set; }
    //    public virtual Author Author { get; set; }

    //    public bool IsFirstAuthor { get; set; }
    //}
    public enum StudyType
    {
        Meta_analysis, Systematic_review, RCT, Cohort_studies, Case_Series, Case_Report, Animal_research, other
    }

    public class Study
    {
        public int StudyID { get; set; }
        public string Title { get; set; }

        public int? DiseaseID { get; set; }
        public virtual Cancer Cancer { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }

        public string StudyRegion { get; set; }
        //public int SubjectPopulation { get; set; }
        //public string SubjectSource { get; set; }
        public int SubjectEnrollmentStartYear { get; set; }
        public int SubjectEnrollmentStopYear { get; set; }

        public StudyType Type { get; set; }

        public int ReferenceID { get; set; }
        public Reference Reference { get; set; }

        public virtual ICollection<Trail> Trails { get; set; }
        public virtual ICollection<TreatmentCondition> SubjectCharactersictics { get; set; }
    }

    public class Reference
    {
        public int ReferenceID { get; set; }

        //public int? StudyID { get; set; }
        //public virtual Study Study { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Number { get; set; }
        public int? PublishingYear { get; set; }
        public int? PageFrom { get; set; }
        public int? PageTo { get; set; }

        [Display(Name = "Full Reference")]
        public string FullReference
        {
            get
            {
                return Name + " " + Volume.ToString() + "(" + Number.ToString() + ")  " + PageFrom.ToString() + "-" + PageTo.ToString() + " " + PublishingYear.ToString();
            }
        }
        public string PubMedCode { get; set; }
        public string Authors { get; set; }
        //public virtual ICollection<ReferenceAuthor> ReferenceAuthors { get; set; }
    }
    //

    //
    public class Outcome
    {
        public int OutcomeID { get; set; }
        public string Name { get; set; }
        public string MeasurementType { get; set; }
        public bool IsAdveseEffect { get; set; }
        public int ImportanceToPatient { get; set; }

        public int TermDefinitionID { get; set; }
        public virtual TermDefinition TermDefinition { get; set; }
    }

    public class TermDefinition
    {
        public int TermDefinitionID { get; set; }
        public string Term { get; set; }
        public string Abbreviation { get; set; }
        public string Definition { get; set; }
        public string Explanation { get; set; }
    }

    //
    public class Trail
    {
        public int TrailID { get; set; }

        //public int TrailTopicID { get; set; }
        //public virtual TrailTopic TrailTopic { get; set; }

        public int? ExperimentalTreatmentOptionID { get; set; }
        public virtual TreatmentPlan ExperimentalTreatment { get; set; }

        public int? ControlTreatmentOptionID { get; set; }
        public virtual TreatmentPlan ControlTreatment { get; set; }

        public int StudyID { get; set; }
        public virtual Study Study { get; set; }

        public string TrailPurpose { get; set; }

        public int ExperimentalPopulation { get; set; }
        public int ControlPopulation { get; set; }

        public string ExperimentalTreatmentNote { get; set; }
        public string ControlTreatmentNote { get; set; }

        public virtual ICollection<TrailOutcome> TrailOutcomes { get; set; }

    }
    //
    public class TrailOutcome
    {
        public int TrailOutcomeID { get; set; }

        public int TrailID { get; set; }
        public virtual Trail Trail { get; set; }

        public int OutcomeID { get; set; }
        public virtual Outcome Outcome { get; set; }

        public double ValueOfExperimentalGroup { get; set; }
        public double ValueOfControlGroup { get; set; }
        public double PopulationOfExperimentalGroupCalculated { get; set; }
        public double PopulationOfControlGroupCalculated { get; set; }
        public double PopulationOfExperimentalGroupAffected { get; set; }
        public double PopulationOfControlGroupAffected { get; set; }

        public string NameOfRelativeEffect { get; set; }
        public double ValueOfRelativeEffect { get; set; }
        public int CondfidenceInterval { get; set; }
        public double LowEndOfCI { get; set; }
        public double HighEndOfCI { get; set; }

        public double PValue { get; set; }

        public double ValueOfAbsoluteEffect { get; set; }
        public string Conclusion { get; set; }
        public string Note { get; set; }
    }
}