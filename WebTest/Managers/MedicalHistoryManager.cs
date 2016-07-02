using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
//
using WebTest.DAL;
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.Helpers;
using WebTest.Controllers;

namespace WebTest.Managers
{
    public class MedicalHistoryManager : BaseController
    {
        static MedicalHistoryManager medicalHistoryManager;
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MedicalHistoryManager()
        {
        }

        public static MedicalHistoryManager Instance
        {
            get
            {
                if (medicalHistoryManager == null)
                {
                    medicalHistoryManager = new MedicalHistoryManager();
                }
                return medicalHistoryManager;
            }
        }
        //
        //
        public SelectList GetAvailablePatientProfiles()
        {
            int userId = 100;
            var profileQuery = from c in db.PatientProfiles
                               where c.UserID == userId
                               orderby c.DiseaseID
                               select new
                               {
                                   PatientProfileID = c.PatientProfileID,
                                   PatientProfileDesc = c.Age.ToString() + " years old, " + c.Gender.ToString() + " with " + c.Disease.Name
                               };
            return new SelectList(profileQuery, "PatientProfileID", "PatientProfileDesc", null);
        }

        //
        public List<PatientMedicalConditionHistoryViewData> GetPatientMedicalConditionHistoryViewData(int patientProfileId)
        {
            int mSpecialtyID = 15;
            int physicianGroupId = 0;

            var allMedicalCondtionsToAsk = db.RequiredMedicalConditionHistories
            .Where(f => f.MedicalSpecialtyID == mSpecialtyID)
            .Where(d => d.PhysicianGroupID == physicianGroupId)
            .Include(d => d.BodySystem)
            .OrderBy(s => s.BodySystemID)
            .ToList();

            var patientMedicalConditionHistories = db.PatientMedicalConditionHistories
            .Include(s => s.RequiredMedicalConditionHistory)
            .Where(d => d.PatientProfileID == patientProfileId)
            .ToList();

            var patientMedicalConditionIds = new HashSet<int>(patientMedicalConditionHistories.Select(f => f.RequiredMedicalConditionHistoryID));
            var viewModel = new List<PatientMedicalConditionHistoryViewData>();

            int prevBodySystemID = 0;

            PatientMedicalConditionHistoryViewData pmc = null;

            foreach (var ds in allMedicalCondtionsToAsk)
            {
                int currBodySystemID = ds.BodySystemID;
                if (currBodySystemID != prevBodySystemID)
                {
                    pmc = new PatientMedicalConditionHistoryViewData();
                    pmc.BodySystemName = ds.BodySystem.Name;
                    pmc.BodySystemTooltip = ds.BodySystem.Desc;
                    pmc.MedicalConditionHistories = new List<MedicalConditionHistoryViewData>();

                    pmc.MedicalConditionHistories.Add(new MedicalConditionHistoryViewData()
                    {
                        MedicalCondition = ds.MedicalCondition,
                        IsSelected = patientMedicalConditionIds.Contains(ds.RequiredMedicalConditionHistoryID)
                    });
                    viewModel.Add(pmc);
                }
                else
                {
                    pmc.MedicalConditionHistories.Add(new MedicalConditionHistoryViewData()
                    {
                        MedicalCondition = ds.MedicalCondition,
                        IsSelected = patientMedicalConditionIds.Contains(ds.RequiredMedicalConditionHistoryID)
                    });
                }
                prevBodySystemID = currBodySystemID;
            }
            return viewModel;
        }

        //
        public List<PatientDiseaseHistoryViewData> GetPatientDiseaseHistoryViewData(int patientProfileId)
        {
            int mSpecialtyID = 15;
            int userGroupId = 0;

            var allDieases = db.RequiredDiseaseHistories
                .Include(s => s.Disease)
                .Where(f => f.MedicalSpecialtyID == mSpecialtyID)
                .Where(d => d.UserGroupID == userGroupId)
                .OrderBy(s => s.Disease.Name)
                .ToList();

            var patientDiseaseHistories = db.PatientDiseaseHistories
                .Include(s => s.RequiredDiseaseHistory)
                .Where(d => d.PatientProfileID == patientProfileId)
                .ToList();

            var patientDieaseIds = new HashSet<int>(patientDiseaseHistories.Select(f => f.RequiredDiseaseHistory.DiseaseID));

            var viewModel = new List<PatientDiseaseHistoryViewData>();
            foreach (var ds in allDieases)
            {
                viewModel.Add(new PatientDiseaseHistoryViewData
                {
                    DiseaseID = ds.Disease.DiseaseID,
                    DiseaseName = ds.Disease.Name,
                    IsSelected = patientDieaseIds.Contains(ds.Disease.DiseaseID)
                });
            }
            return viewModel;
        }

        //
        public List<PatientSurgicalHistoryViewData> GetPatientSurgicalHistoryViewData(int patientProfileId)
        {
            int mSpecialtyID = 15;
            int userId = 0;

            var allSurgeries = db.RequiredSurgicalHistories
                .Include(d => d.Treatment)
                .Where(g => g.MedicalSpecialtyID == mSpecialtyID)
                .Where(s => s.UserGroupID == userId)
                .OrderBy(s => s.Treatment.Name)
                .ToList();

            var patientSurgeryHistories = db.PatientSurgicalHistories
                .Include(s=>s.RequiredSurgicalHistory)
                .Where(d => d.PatientProfileID == patientProfileId)
                .ToList();

            var patientSurgeryIds = new HashSet<int>(patientSurgeryHistories.Select(d => d.RequiredSurgicalHistory.TreatmentID));
            var viewModel = new List<PatientSurgicalHistoryViewData>();

            foreach (var sh in allSurgeries)
            {
                viewModel.Add(new PatientSurgicalHistoryViewData
                {
                    TreatmentID = sh.TreatmentID,
                    SurgeryName = sh.Treatment.Name,
                    IsSelected = patientSurgeryIds.Contains(sh.TreatmentID)
                });
            }
            return viewModel;
        }
        //
        public List<SystemReviewViewData> GetPatientSystemReviewViewData(int patientProfileId)
        {
            int mSpecialtyID = 15;
            int userGroupId = 0;

            var patientSystemReviews = db.PatientSystemReviews
                .Include(s => s.RequiredSystemReview)
                .Where(s => s.PatientProfileID == patientProfileId)
                .ToList();
            //logger.Debug("patientProfileId=" + patientProfileId);
            //logger.Debug("patient system ewview count=" + patientSystemReviews.Count);
            var requiredSystemReviews = db.RequiredSystemReviews
                .Include( a => a.DiagnosticFactor)
                .Include(s => s.DiagnosticFactor.BodySystem)
                .Where(s => s.MedicalSpecialtyID == mSpecialtyID)
                .Where(s => s.UserGroupID == userGroupId)
                .ToList();
                
            var allSystems = requiredSystemReviews.Select(d => d.DiagnosticFactor.BodySystem).ToList().Distinct();
            //var allSymtpoms = requiredSystemReviews.Select(d => d.DiagnosticFactor);

            var patientSymptomIds = new HashSet<int>();
            if(patientSystemReviews.Count > 0){
                patientSymptomIds = new HashSet<int>(patientSystemReviews.Select(s => s.RequiredSystemReviewID));
            }
            //logger.Debug("patient symptom count=" + patientSymptomIds.Count);
            var viewModel = new List<SystemReviewViewData>();
            foreach (var bs in allSystems)
            {
                var mySr = new SystemReviewViewData();
                mySr.SystemName = bs.Name;
                mySr.SymptomReviewViewDataList = new List<SymptomReviewViewData>();
                foreach (var sptm in requiredSystemReviews.Where(s => s.DiagnosticFactor.BodySystem.BodySystemID == bs.BodySystemID))
                {
                    mySr.SymptomReviewViewDataList.Add(new SymptomReviewViewData
                    {
                        DiagnosticFactorID = sptm.DiagnosticFactorID,
                        SymtomName = sptm.DiagnosticFactor.Name,
                        IsSelected = patientSymptomIds.Contains(sptm.DiagnosticFactorID)
                    });
                }
                viewModel.Add(mySr);

            }
            return viewModel;
        }

        public PatientFamilyDiseaseHistoryViewData GetPatientFamilyHistoryViewData(int patientProfileId)
        {
            int mSpecialtyID = 15;
            int userGroupId = 0;

            var diseasesToReview = db.RequiredFamilyDiseaseHistories
                .Include(s=>s.Disease)
                .Where(s => s.MedicalSpecialtyID == mSpecialtyID)
                .Where(s => s.UserGroupID == userGroupId)
                .ToList();
            var patientFamilyDiseaseHistories = db.PatientFamilyDiseaseHistories
                .Where(s => s.PatientProfileID == patientProfileId);
            
            
            //logger.Debug("2=" + System.DateTime.Now);
            
            var diseaseIdsHS = new HashSet<int>(diseasesToReview.Select(s => s.Disease.DiseaseID));
            var familyDiseaseIdsHS = new HashSet<int>(patientFamilyDiseaseHistories.Select(s => s.RequiredFamilyDiseaseHistory.DiseaseID));
            

            var ViewModel = new PatientFamilyDiseaseHistoryViewData();
            ViewModel.FamilyMembers = Enum.GetValues(typeof(FamilyMember)).Cast<FamilyMember>().Select(v => v).ToList();
            ViewModel.FamilyDiseaseHistories = new List<FamilyDiseaseHistoryViewData>();

            //logger.Debug("3=" + System.DateTime.Now);

            //var familyDiseaseIds = new HashSet<int>(patientFamilyMedicalHistories.Select(d => d.DiseaseID));
            //
            foreach (var rDisease in diseasesToReview)
            {
                    var familyDiseaseHistoryViewData = new FamilyDiseaseHistoryViewData();
                    familyDiseaseHistoryViewData.DiseaseID = rDisease.DiseaseID;
                    familyDiseaseHistoryViewData.DiseaseName = rDisease.Disease.Name;
                    //logger.Debug("disease.Name=" + disease.Name);
                    familyDiseaseHistoryViewData.MemberDiseaseHistories = new List<FamilyMemberDiseaseHistoryViewData>();
                    foreach (var mrb in ViewModel.FamilyMembers)
                    {
                        FamilyMemberDiseaseHistoryViewData memberDiseaseViewData = new FamilyMemberDiseaseHistoryViewData();
                        memberDiseaseViewData.Member = mrb;
                        memberDiseaseViewData.HasDiagnosed = false;
                        familyDiseaseHistoryViewData.MemberDiseaseHistories.Add(memberDiseaseViewData);
                    }
                    if (familyDiseaseIdsHS.Contains(rDisease.DiseaseID))
                    {
                        var familyHx = patientFamilyDiseaseHistories.Where(s => s.RequiredFamilyDiseaseHistory.DiseaseID == rDisease.DiseaseID).ToList();
                        foreach (var fMemberHx in familyDiseaseHistoryViewData.MemberDiseaseHistories)
                        {
                            if (familyHx.Select(d => d.FamilyMember).Contains(fMemberHx.Member))
                            {
                                fMemberHx.HasDiagnosed = true;
                            }
                        }
                    }
                    ViewModel.FamilyDiseaseHistories.Add(familyDiseaseHistoryViewData);
            }
            //logger.Debug("4=" + System.DateTime.Now);
            return ViewModel;
        }
        //
        public PatientSocialHistoryViewData GetPatientSocialHistoryViewData(int patientProfileId)
        {
            PatientSocialHistoryViewData patientSocialHistoryViewData = new PatientSocialHistoryViewData();
            var patientSocialHistory = db.PatientSocialHistories.Find(patientProfileId);
            patientSocialHistoryViewData.MaritalStatus = patientSocialHistory.MaritalStatus;
            patientSocialHistoryViewData.EmploymentStatus = patientSocialHistory.EmploymentStatus;
            patientSocialHistoryViewData.ExerciseLevel = patientSocialHistory.ExerciseLevel;
            patientSocialHistoryViewData.CurrentJob = patientSocialHistory.CurrentJob;
            //
            List<Substance> substaneces = Enum.GetValues(typeof(Substance)).Cast<Substance>().ToList();
            List<PatientSubstanceUseViewData> substanceUses = new List<PatientSubstanceUseViewData>();
            foreach (var substance in substaneces)
            {
                PatientSubstanceUseViewData patientSubstanceUse = new PatientSubstanceUseViewData();
                if (patientSocialHistory.SubstanceUses.Select(s => s.Substance).Contains(substance))
                {
                    PatientSubstanceUse subUse = patientSocialHistory.SubstanceUses.Where(d => d.Substance == substance).SingleOrDefault();
                    patientSubstanceUse.Substance = subUse.Substance;
                    patientSubstanceUse.IsCurrentInUse = subUse.IsCurrentInUse;
                    patientSubstanceUse.IsPastInUse = subUse.IsPastInUse;
                    patientSubstanceUse.Quantity = subUse.Quantity;
                    patientSubstanceUse.LengthInYear = subUse.LengthInYear;
                    patientSubstanceUse.StoppedInYear = subUse.StoppedInYear;
                }
                else
                {
                    patientSubstanceUse = new PatientSubstanceUseViewData();
                    patientSubstanceUse.Substance = substance;
                }
                substanceUses.Add(patientSubstanceUse);
            }
            patientSocialHistoryViewData.SubstanceUses = substanceUses;
            //patientSocialHistoryViewData.SocialHistory.SubstanceUses = substanceUses;
            //
            return patientSocialHistoryViewData;
        }

        public List<PatientMedicationHistory> GetPatientMedicationHistories(int patientProfileId)
        {
            var patientMedicationHistory = db.PatientMedicationHistories
                .Where(s => s.PatientProfileID == patientProfileId).ToList();
            return patientMedicationHistory;
        }
        public List<PatientAllergyHistory> GetPatientAllergyHistories(int patientProfileId)
        {
            var patientAllergyHistory = db.PatientAllergyHistories
                .Where(s => s.PatientProfileID == patientProfileId).ToList();
            return patientAllergyHistory;
        }
    }
}