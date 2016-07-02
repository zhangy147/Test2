using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC5.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC5.DatabaseContexts
{
    public class SiteDbContext : DbContext
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Cancer> Cancers { get; set; }
        public DbSet<StatRate> StatRates { get; set; }
        public DbSet<CancerCellType> CancerCellTypes { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<TNMStage> TNMStages { get; set; }
        public DbSet<TNMDefinition> TNMDefinitions { get; set; }
        //
        //public DbSet<FactorValue> FactorValues { get; set; }
        public DbSet<TreatmentFactor> TreatmentFactors { get; set; }
        public DbSet<DiseaseTreatmentFactor> DiseaseTreatmentFactors { get; set; }
        public DbSet<TreatmentIndication> TreatmentIndications { get; set; }
        //        
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<CancerProcedure> CancerProcedures { get; set; }
        //public DbSet<CancerProcedurePurpose> CancerProcedurePurposes { get; set; }
        //public DbSet<ClinicalEvaluation> ClinicalEvaluations { get; set; }
        //
        public DbSet<Author> Authors { get; set; }
        //public DbSet<ReferenceAuthor> ReferenceAuthors { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Study> Studies { get; set; }

        public DbSet<Trail> Trails { get; set; }
        //public DbSet<TrailTopic> TrailTopics { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<TrailOutcome> TrailOutcomes { get; set; }
        public DbSet<TermDefinition> TermDefinitions { get; set; }
        //
        public DbSet<PatientProfile> PatientProfiles { get; set; }

        public DbSet<AdvisingAuthority> AdvisingAuthorities { get; set; }
        //
        public DbSet<TreatmentImplementation> TreatmentImplementations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentOption> TreatmentOptions { get; set; }

        public DbSet<CancerTreatmentPlan> CancerTreatmentPlans { get; set; }
        //
        //

        //public DbSet<Article> Articles { get; set; }
        //public DbSet<Section> Sections { get; set; }
        //public DbSet<KeyPoint> KeyPoints { get; set; }
        //public DbSet<Paragraph> Paragraphs { get; set; }
        ////public DbSet<ParagraphBulletinPoint> ParagraphBulletinPoints { get; set; }
        ////public DbSet<TableOfContent> TableOfContents { get; set; }
        //public DbSet<DisplayImage> DisplayImages { get; set; }
        //
        //
        //for symptom checker
        public DbSet<BodySystem> BodySystems { get; set; }
        public DbSet<DiagnosticFactor> DiagnosticFactors { get; set; }
        // public DbSet<DiseaseDiagnosticFactor> DiseaseDiagnosticFactors { get; set; }
        public DbSet<DiagnosticFactorCharacter> DiagnosticFactorCharacters { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        //
        public DbSet<PatientCharacter> PatientCharacters { get; set; }
        public DbSet<DiseasePrevalence> DiseasePrevalences { get; set; }

        public DbSet<DiagnosticFinding> DiagnosticFindings { get; set; }
        public DbSet<DiseaseDiagnosticFinding> DiseaseDiagnosticFindings { get; set; }
        public DbSet<DiseaseDiagnositicRule> DiseaseDiagnositicRules { get; set; }
        //
        //public DbSet<MedicalTerm> MedicalTerms { get; set; }
        //
        //
        /// <summary>
        /// the following declarations are for Service Manager
        /// </summary>
        public DbSet<PatientSystemReview> PatientSystemReviews { get; set; }
        public DbSet<PatientMedicalHistory> PatientMedicalHistories { get; set; }
        public DbSet<PatientSurgicalHistory> PatientSurgicalHistories { get; set; }
        public DbSet<PatientFamilyMedicalHistory> PatientFamilyMedicalHistories { get; set; }
        public DbSet<PatientSocialHistory> PatientSocialHistories { get; set; }
        public DbSet<Antigen> Antigens { get; set; }
        public DbSet<AllergyReaction> AllergyReactions { get; set; }
        public DbSet<PatientAllergyHistory> PatientAllergyHistories { get; set; }
        public DbSet<PatientDrugHistory> PatientDrugHistories { get; set; }
        public DbSet<SideEffect> SideEffects { get; set; }
        public DbSet<DrugCategory> DrugCategories { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<SubstanceUse> SubstanceUses { get; set; }

        //
        public DbSet<ConsultingService> ConsultingServices { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<RequestedService> RequestedServices { get; set; }
        //
        public DbSet<PatientQuestion> PatientQuestions { get; set; }
        //public DbSet<SuggestedReading> SuggestedReadings { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<PhysicianNote> PhysicianNotes { get; set; }
        //public DbSet<PatientNote> PatientNotes { get; set; }
        public DbSet<ServiceReport> ServiceReports { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<PatientMedicalRecord> PatientMedicalRecords { get; set; }
        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disease>().HasMany(c => c.MedicalRecords).WithMany().Map(s => s.MapLeftKey("DiseaseID").MapRightKey("MedicalRecordID").ToTable("DiseaseMedicalRecords"));
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Cancer>().HasMany(c => c.Stages).WithRequired(c => c.Cancer).HasForeignKey(p => p.DiseaseID);
            modelBuilder.Entity<Cancer>().HasMany(c => c.TNMDefinitions).WithRequired(c => c.Cancer).HasForeignKey(p => p.DiseaseID);
            modelBuilder.Entity<Cancer>().HasMany(c => c.CellTypes).WithRequired(c => c.Cancer).HasForeignKey(p => p.DiseaseID);
            modelBuilder.Entity<Cancer>().HasMany(c => c.StatRates).WithRequired(c => c.Cancer).HasForeignKey(p => p.DiseaseID);
            //modelBuilder.Entity<Cancer>().HasMany(c => c.Procedures).WithRequired(c => c.
            //
            modelBuilder.Entity<Stage>().HasKey(a => new { a.DiseaseID, a.StageCode });
            //
            modelBuilder.Entity<Stage>().HasMany(s => s.TNMStages).WithRequired().HasForeignKey(p => new { p.DiseaseID, p.StageCode });
            //modelBuilder.Entity<Stage>().HasMany(s => s.Studies).WithMany(s => s.Stages).Map(t => t.MapLeftKey("StageID").MapRightKey("StudyID").ToTable("CancerStudy"));
            //modelBuilder.Entity<Stage>().HasMany(s => s.TreatmentFactors).WithRequired().HasForeignKey(p => new { p.DiseaseID, p.StageCode });
            //
            ////modelBuilder.Entity<FactorValue>().HasMany(s => s.DecisionConditions).WithRequired(a => a.FactorValue).HasForeignKey(a => a.FactorValueID);
            //
            //modelBuilder.Entity<TreatmentFactor>().HasRequired(f => f.FactorKey).WithMany().HasForeignKey(f => f.FactorKeyID);
            //modelBuilder.Entity<TreatmentFactor>().HasRequired(f => f.Stage).WithMany().HasForeignKey(f => new { f.DiseaseID, f.StageCode });
            //
            //modelBuilder.Entity<Study>().HasMany(s=>s.Stages).WithMany().Map(f => f.MapLeftKey("StudyID").MapRightKey("DieaseID").MapRightKey("StageCode").ToTable("StudyStages"));
            modelBuilder.Entity<Study>().HasRequired(s => s.Cancer).WithMany().HasForeignKey(f => f.DiseaseID);
            modelBuilder.Entity<Study>().HasRequired(s => s.Reference);
            modelBuilder.Entity<Study>().HasMany(d => d.Trails).WithRequired(d => d.Study).HasForeignKey(d => d.StudyID);
            //modelBuilder.Entity<Treatment>().HasMany(s => s.TreatmentsInStudy).WithRequired(f => f.ControlTreatment).HasForeignKey(d => d.ControlTreatmentID);

            //modelBuilder.Entity<Reference>().HasMany(s => s.ReferenceAuthors).WithRequired(s => s.Reference).HasForeignKey(a => a.AuthorID);

            //modelBuilder.Entity<TrailTopic>().HasOptional(s => s.ExperimentalTreatment).WithMany().HasForeignKey(s => s.ExperimentalTreatmentID);
            //modelBuilder.Entity<TrailTopic>().HasOptional(s => s.ControlTreatment).WithMany().HasForeignKey(s => s.ControlTreatmentID);
            modelBuilder.Entity<Trail>().HasOptional(s => s.ExperimentalTreatment).WithMany().HasForeignKey(s => s.ExperimentalTreatmentOptionID);
            modelBuilder.Entity<Trail>().HasOptional(s => s.ControlTreatment).WithMany().HasForeignKey(s => s.ControlTreatmentOptionID);
            //
            //
            modelBuilder.Entity<TrailOutcome>().HasRequired(s => s.Outcome).WithMany().HasForeignKey(d => d.OutcomeID);
            modelBuilder.Entity<TrailOutcome>().HasRequired(s => s.Trail).WithMany().HasForeignKey(d => d.TrailID);

            //
            //modelBuilder.Entity<Procedure>().HasMany(s => s.StagesAppliedTo).WithMany(d => d.RequiredProcedures).Map(t => t.MapLeftKey("StageID").MapRightKey("ProcedureID").ToTable("StageProcedures"));
            //
            //modelBuilder.Entity<TreatmentInDecision>().HasMany(f => f.SupportingStudies).WithMany().Map(f => f.MapLeftKey("TreatmentDecisionDeatilID").MapRightKey("StudyID").ToTable("TreatmentSupportingStudies"));
            //modelBuilder.Entity<TreatmentDecisionHead>().HasMany(f => f.DecisionConditions).WithMany(f=>f.TreatmentDecisionHeads).Map(f=>f.MapLeftKey("TreatmentDecisionHeadID").MapRightKey("DecisionConditionID").ToTable("DecisionPaths"));
            //modelBuilder.Entity<TreatmentDecisionHead>().HasMany(f => f.RecommendedBy).WithMany().Map(f => f.MapLeftKey("TreatmentDecisionHeadID").MapRightKey("AuthorityID").ToTable("TreatmentAdvisingAuthorities"));

            //
            //modelBuilder.Entity<ClinicalEvaluation>().HasMany(f => f.RecommendedProcedures).WithMany(s => s.ClinicalEvaluations).Map(x=>x.MapLeftKey("ClinicalEvaluationID").MapRightKey("ProcedureID").ToTable("EvaluationProcedures"));


            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.Questions).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("QuestionID").ToTable("PatientQuestions"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.ReceivedProcedures).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("ProcedureID").ToTable("PatientReceivedProcedures"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.ReceivedTreatments).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("TreatmentID").ToTable("PatientReceivedTreatments"));
            ////modelBuilder.Entity<PatientProfile>().HasMany(d => d.UploadedRecords).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("UploadedRecordID").ToTable("PatientUploadedRecords"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.RequestedServices).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("ServiceID").ToTable("PatientRequestedServices"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.SuggestedReadings).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("SuggestedReadingID").ToTable("PatientSuggestedReadings"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.PhysicianNotes).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("NoteID").ToTable("PatientNotes"));
            //modelBuilder.Entity<PatientProfile>().HasMany(d => d.PhysicianNotes).WithMany().Map(f => f.MapLeftKey("PatientProfileID").MapRightKey("PhysicianNoteID").ToTable("PhysicianNotes"));


            //modelBuilder.Entity<PatientProfile>().HasRequired(f => f.Cancer).WithMany().HasForeignKey(c => c.DiseaseID);
            //modelBuilder.Entity<PatientProfile>().HasOptional(f => f.InitialStage).WithMany().HasForeignKey(c => new { c.DiseaseID, c.InitialStageCode });
            //modelBuilder.Entity<PatientProfile>().HasOptional(f => f.FinalStage).WithMany().HasForeignKey(c => new { c.DiseaseID, c.FinalStageCode });
            //modelBuilder.Entity<PatientProfile>().HasMany(f => f.TreatmentIndications).WithMany(d => d.PatientProfiles).Map(s => s.MapLeftKey("PatientProfileID").MapRightKey("TreatmentIndicationID").ToTable("PatientTreatmentIndications"));
            //modelBuilder.Entity<PatientProfile>().HasMany(f => f.ProceduresDone).WithMany(d => d.PatientProfiles).Map(s => s.MapLeftKey("PatientProfileID").MapRightKey("ProcedureID").ToTable("PatientProcedures"));

            //modelBuilder.Entity<PatientProfile>().HasRequired(f => f.DecisionPath).WithMany().HasForeignKey(d=>d.DecisionPathID);
            modelBuilder.Entity<CancerTreatmentPlan>().HasMany(f => f.SupportingStudies).WithMany().Map(f => f.MapLeftKey("CancerTreatmentPlanID").MapRightKey("StudyID").ToTable("TreatmentSupportingStudies"));
            //modelBuilder.Entity<TreatmentDetail>().HasOptional(f => f.Drugs).WithOptionalDependent().Map(f => f.MapKey("DrugID").ToTable("TreatmentAgents"));
            modelBuilder.Entity<CancerTreatmentPlan>().HasMany(f => f.Indications).WithMany().Map(f => f.MapLeftKey("CancerTreatmentPlanID").MapRightKey("TreatmentIndicationID").ToTable("CancerTreatmentPlanIndications"));
            modelBuilder.Entity<CancerTreatmentPlan>().HasMany(f => f.InitialTreatmentOptions).WithMany().Map(f => f.MapLeftKey("CancerTreatmentPlanID").MapRightKey("TreatmentOptionID").ToTable("TreatmentPlanInitialOptions"));
            modelBuilder.Entity<CancerTreatmentPlan>().HasMany(f => f.AdditionalTreatmentOptions).WithMany().Map(f => f.MapLeftKey("CancerTreatmentPlanID").MapRightKey("TreatmentOptionID").ToTable("TreatmentPlanAdditionalOptions"));
            modelBuilder.Entity<TreatmentOption>().HasMany(f => f.Indications).WithMany().Map(f => f.MapLeftKey("TreatmentOptionID").MapRightKey("TreatmentIndicationID").ToTable("TreatmentOptionIndications"));
            //
            //for Disease general information
            //modelBuilder.Entity<Article>().HasMany(f => f.Sections).WithMany().Map(f => f.MapLeftKey("ArticleID").MapRightKey("SectionID").ToTable("ArticleSections"));
            //modelBuilder.Entity<Section>().HasMany(f => f.KeyPoints).WithMany().Map(f => f.MapLeftKey("SectionID").MapRightKey("KeyPointID").ToTable("SectionKeyPoints"));
            //modelBuilder.Entity<KeyPoint>().HasMany(f => f.Paragraphs).WithMany().Map(f => f.MapLeftKey("KeyPointID").MapRightKey("ParagraphID").ToTable("KeyPointParagraphs"));
            //modelBuilder.Entity<Article>().HasMany(f => f.References).WithMany().Map(f => f.MapLeftKey("ArticleID").MapRightKey("ReferenceID").ToTable("ArticleReferences"));
            //
            //for SymptomChecker
            //relationship between Symptom and Prompt
            //modelBuilder.Entity<Symptom>().HasMany(s => s.SymptomPrompts).WithRequired(x => x.Symptom).HasForeignKey(d => d.SymptomID);
            //relationship between Symptom and BodyPart
            modelBuilder.Entity<Symptom>().HasRequired(s => s.BodyPart).WithMany().HasForeignKey(c => c.BodyPartID);
            //relationship betweeb Prompt and State
            //modelBuilder.Entity<SymptomPrompt>().HasMany(s => s.SymptomStates).WithRequired(d => d.SymptomPrompt).HasForeignKey(c => c.SymptomPromptID);
            //relationship between State and Diagnosis
            //modelBuilder.Entity<DiagnosisReply>().HasMany(s => s.SymptomStates).WithMany(j => j.DiagnosisReplies).Map(a => a.MapLeftKey("DiagnosisReplyID").MapRightKey("SymptomStatusID").ToTable("DiagnosisMatrix"));
            //relationship between State and Next Prompt
            //
            //modelBuilder.Entity<SymptomPromptStep>().HasRequired(d => d.SymptomState).WithMany().HasForeignKey(f=>f.SymptomStateID);
            //modelBuilder.Entity<SymptomPromptStep>().HasRequired(d => d.Prompt).WithMany().HasForeignKey(f=>f.NextPromptID);
            //modelBuilder.Entity<MedicalTerm>().HasMany(f => f.RelatedTerms).WithMany().Map(a => a.MapLeftKey("MedicalTermID").MapRightKey("MedicalTermID").ToTable("RelatedTerms"));
            modelBuilder.Entity<ServiceProvider>().HasMany(s => s.ConsultingServices).WithMany().Map(f => f.MapLeftKey("ProviderID").MapRightKey("ServiceID").ToTable("ProviderServices"));

        }
    }
}