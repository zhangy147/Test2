using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
//
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;

namespace WebTest.Controllers
{
    public class DiseaseStateController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //
        //=================================================
        // Disease Procedures
        //=================================================
        [HttpGet]
        public ActionResult GetDiseaseProcedures()
        {
            int diseaseId = 4;
            var proceduresViewData = PatientProfileManager.Instance.GetEvaluationProcedures(diseaseId);
            //logger.Debug("proceduresViewData.Count()=" + proceduresViewData.Count);
            return PartialView("_ProceduresReceivedTab", proceduresViewData);
        }
        //
        [HttpPost]
        public ActionResult SaveReceivedProcedures(List<DiseaseProcedureViewData> diseaseProcedures, string nextPage)
        {
            int diseaseId = 4;
            
            if (diseaseProcedures != null)
            {
                //logger.Debug("the count of selected procedures is: " + diseaseProcedures.Count());
     
               var procedures = PatientProfileManager.Instance.GetEvaluationProcedures(diseaseId);
                //
               return RedirectToNextPage(nextPage);
            }
            return PartialView("_ProceduresReceivedTab", diseaseProcedures);
        }
        /// ===============================================================================
        /// Initial Treatment factors
        /// ===============================================================================
        [HttpGet]
        public ActionResult GetInitialTreatmentFactors()
        {
            var txFactors = new List<DiseaseTreatmentFactorViewData>();
            int profileId = GetCurrentPatientProfileID();
            int diseaseId = GetCurrentDiseaseID();

            profileId = 2;
            diseaseId = 4;

            if (profileId > 0 && diseaseId > 0)
            {
                //logger.Debug("GetInitalFactors, diseaseId" + patientProfile.DiseaseID);
                txFactors = PatientProfileManager.Instance.GetInitialTreatmentFactors(diseaseId);
                HashSet<int> patientSelectedConditionIds = GetPatientTreatmentConditionIds(profileId);
                txFactors = MapPatientSelectedConditions(txFactors, patientSelectedConditionIds);
            }
            return PartialView("_InitialTreatmentFactorsTab", txFactors);
        }

        [HttpPost]
        public ActionResult SaveInitialTreatmentFactors(List<DiseaseTreatmentFactorViewData> inputFactors, string nextPage)
        {
            //logger.Debug("SaveTreatmentFactors: " + inputFactors.Count + "  Category=" + Category);

            if (inputFactors != null)
            {
                logger.Debug("SaveTreatmentFactors: " + inputFactors.Count);
                //
                HashSet<int> inputConditionIds = GetInputConditionIds(inputFactors);
                inputConditionIds = SavePatientTreatmentConditions(inputConditionIds);

                return RedirectToNextPage(nextPage);

            }
            return PartialView("_InitialTreatmentFactorsTab", inputFactors);
        }

        [HttpGet]
        public ActionResult GetTreatmentFactorsII()
        {
            int category = 1;
            int currentPatientProfileId = GetCurrentPatientProfileID();
            var treatmentFactorsForPatientCurrentState = new List<DiseaseTreatmentFactorViewData>();

            logger.Debug("GetTreatmentFactorsII");

            if (currentPatientProfileId != 0)
            {
                int diseaseId = GetCurrentDiseaseID();
                HashSet<int> patientTreatmentConditionIds = GetPatientTreatmentConditionIds(currentPatientProfileId);
                treatmentFactorsForPatientCurrentState = PatientProfileManager.Instance.GetNextDiseaseTreatmentFactorsViewData(diseaseId, patientTreatmentConditionIds, category);
                treatmentFactorsForPatientCurrentState = MapPatientSelectedConditions(treatmentFactorsForPatientCurrentState, patientTreatmentConditionIds);
            }
            return PartialView("_TreatmentFactorsIITab", treatmentFactorsForPatientCurrentState);
        }

        //
        [HttpPost]
        public ActionResult SaveTreatmentFactorsII(List<DiseaseTreatmentFactorViewData> inputFactors, string nextPage)
        {
            int diseaseId = GetCurrentDiseaseID();
            var returnList = new List<DiseaseTreatmentFactorViewData>();

            //logger.Debug("SaveTreatmentFactorsII: " + inputFactors.Count + ");

            if (inputFactors != null)
            {
                logger.Debug("SaveTreatmentFactors: " + inputFactors.Count);
                //
                HashSet<int> inputConditionIds = GetInputConditionIds(inputFactors);
                inputConditionIds = SavePatientTreatmentConditions(inputConditionIds);

                return RedirectToNextPage(nextPage);
               
            }
            return PartialView("_TreatmentFactorsIITab", inputFactors);
        }
        //
        //==========================================================================
        // Treatment Factors II ()
        //==========================================================================
        [HttpGet]
        public ActionResult GetTreatmentFactorsIII()
        {
            int category = 2;
            var treatmentFactorsForPatientGeneralHealth = new List<DiseaseTreatmentFactorViewData>();
            int currentPatientProfileId = GetCurrentPatientProfileID();
            if (currentPatientProfileId != 0)
            {
                int diseaseId = GetCurrentDiseaseID();
                HashSet<int> patientTreatmentConditionIds = GetPatientTreatmentConditionIds(currentPatientProfileId);
                treatmentFactorsForPatientGeneralHealth = PatientProfileManager.Instance.GetNextDiseaseTreatmentFactorsViewData(diseaseId, patientTreatmentConditionIds, category);
                treatmentFactorsForPatientGeneralHealth = MapPatientSelectedConditions(treatmentFactorsForPatientGeneralHealth, patientTreatmentConditionIds);
            }
            return PartialView("_TreatmentFactorsIIITab", treatmentFactorsForPatientGeneralHealth);
        }


        [HttpPost]
        public ActionResult SaveTreatmentFactorsIII(List<DiseaseTreatmentFactorViewData> inputFactors, string Category, string nextPage)
        {
            if (inputFactors != null)
            {
                //save factors
                logger.Debug("treatment fator III was saved");
                return RedirectToNextPage(nextPage);
            }
            return PartialView("_TreatmentFactorsIIITab", inputFactors); 
        }
        /// <summary>
        /// Private functions
        /// </summary>
        /// <param name="factors"></param>
        /// <returns></returns>
        private HashSet<int> GetInputConditionIds(List<WebTest.ViewModels.DiseaseTreatmentFactorViewData> factors)
        {
            HashSet<int> inputConditionIds = new HashSet<int>();
            foreach (var f in factors)
            {
                inputConditionIds.UnionWith(f.SelectedTreatmentConditionID.ToList());
            }
            return inputConditionIds;
        }
        //
        private List<PatientTreatmentCondition> GetPatientTreatmentConditions(int patientProfileId)
        {
            return db.PatientTreatmentConditions
                    .Where(s => s.PatientProfileID == patientProfileId)
                    .ToList();
        }

        private HashSet<int> GetPatientTreatmentConditionIds(int patientProfileId)
        {
            List<PatientTreatmentCondition> patientTreatmentConditions = GetPatientTreatmentConditions(patientProfileId);
            return new HashSet<int>(patientTreatmentConditions.Select(f => f.TreatmentConditionID));
        }


        //public PatientProfile GetPatientProfile(int profileId)
        //{
        //    if (profileId > 0)
        //    {
        //        PatientProfile currProfile = db.PatientProfiles
        //        .Where(d => d.PatientProfileID == profileId)
        //        .Single();
        //        //
        //        //currProfile.ReceivedProcedures = db.PatientReceivedProcedures
        //        //   .Where(s => s.PatientProfileID == currProfile.PatientProfileID)
        //        //   .ToList();
        //        ////
        //        //currProfile.TreatmentConditions = db.PatientTreatmentConditions
        //        //    .Where(s => s.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        ////
        //        //currProfile.DiseaseHistories = db.PatientDiseaseHistories
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        //currProfile.SurgicalHistories = db.PatientSurgicalHistories
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        //currProfile.SystemReviews = db.PatientSystemReviews
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        //currProfile.SocialHistory = db.PatientSocialHistories
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .SingleOrDefault();
        //        //currProfile.FamilyDiseaseHistories = db.PatientFamilyDiseaseHistories
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        ////
        //        //currProfile.MedicalRecords = db.PatientMedicalRecords
        //        //    .Where(d => d.PatientProfileID == currProfile.PatientProfileID)
        //        //    .ToList();
        //        return currProfile;
        //    }
        //    return null;
        //}
        private HashSet<int> SavePatientTreatmentConditions(HashSet<int> inputConditionIds)
        {
            //save to database
            return inputConditionIds;
        }
        //

        private List<DiseaseTreatmentFactorViewData> MapPatientSelectedConditions(List<DiseaseTreatmentFactorViewData> txFactors, HashSet<int> patientConditionIds)
        {
            foreach (var factorVD in txFactors)
            {
                foreach (var condition in factorVD.Conditions)
                {
                    //logger.Debug("ConditionID in extracted factor=" + condition.ConditionID);
                    if (patientConditionIds.Contains(condition.ConditionID))
                    {
                        condition.IsSelected = true;
                    }
                }
            }
            return txFactors;
        }
        private DiseaseTreatmentFactorViewData GetNextTreatmentFactorViewData(List<WebTest.ViewModels.DiseaseTreatmentFactorViewData> factors)
        {
            int diseaseId = 4;
            int allIndications = 0, excludedIndications = 0, matchedIndications = 0;
            TreatmentFactor nextTxFactor = null;
            //
            List<DiseaseTreatmentFactorViewData> returnList = GetTreatmentFactorViewDataList(factors);
            List<DiseaseTreatmentIndication> NeedRevisitedIndications = new List<DiseaseTreatmentIndication>();
            //
            //prepare input factors and conditions
            HashSet<int> inputFactorIds = new HashSet<int>(factors.Select(s => s.FactorID).ToList());
            HashSet<int> inputConditionIds = GetInputConditionIds(factors);
            //
            HashSet<int> composedConditionIds = FindComposedTreatmentConditionIds(inputFactorIds, inputConditionIds);
            inputConditionIds.UnionWith(composedConditionIds);
            //
            HashSet<int> excludedConditionIds = FindExludedTreatmentConditionIds(inputFactorIds, inputConditionIds);
            //
            var allTreatmentIndications = db.DiseaseTreatmentIndications.Where(s => s.DiseaseID == diseaseId).ToList();
            allIndications = allTreatmentIndications.Count;
            List<DiseaseTreatmentIndication> IndicationsToVisit = new List<DiseaseTreatmentIndication>();
            HashSet<int> toBeVisitedConditionIds = new HashSet<int>();
            HashSet<int> toBeVisitedFactorIds = new HashSet<int>();
            //
            foreach (var indication in allTreatmentIndications)
            {
                var conditionIdsInIndication = new HashSet<int>(indication.TreatmentConditions.Select(d => d.TreatmentConditionID));
                if (conditionIdsInIndication.Overlaps(excludedConditionIds))
                {
                    excludedIndications++;
                }
                else if (conditionIdsInIndication.IsSubsetOf(inputConditionIds))
                {
                    matchedIndications++;
                }
                else
                {
                    IndicationsToVisit.Add(indication);
                    toBeVisitedConditionIds.UnionWith(indication.TreatmentConditions.Select(s => s.TreatmentConditionID));
                    toBeVisitedFactorIds = GetTreatmentFactorIds(toBeVisitedConditionIds);
                }
            }
            bool IsLasFactor = toBeVisitedFactorIds.Count == 1 ? true : false;

            foreach (var indication in allTreatmentIndications)
            {
                HashSet<int> indicatedConditions = new HashSet<int>(indication.TreatmentConditions.Select(s => s.TreatmentConditionID));
                if (indicatedConditions.Overlaps(inputConditionIds))
                {

                    indicatedConditions.ExceptWith(inputConditionIds);
                    int fisrtConditionId = indicatedConditions.First();
                    //logger.Debug("fisrtConditionId=" + fisrtConditionId);
                    nextTxFactor = FindTreatmentFactor(fisrtConditionId);
                    break;
                }
                else
                {
                    NeedRevisitedIndications.Add(indication);
                }
            }

            if (nextTxFactor == null && NeedRevisitedIndications.Count > 0)
            {
                int firstConditionId = NeedRevisitedIndications.First().TreatmentConditions.First().TreatmentConditionID;
                nextTxFactor = FindTreatmentFactor(firstConditionId);
            }
            DiseaseTreatmentFactorViewData txFactorViewData = CreateDiseaseTreatmentFactorViewData(nextTxFactor);
            txFactorViewData.IsLast = IsLasFactor;
            return txFactorViewData;
        }
        private HashSet<int> FindComposedTreatmentConditionIds(HashSet<int> inputFactors, HashSet<int> txConditionIds)
        {
            HashSet<int> composedConditionIds = new HashSet<int>();
            var composedTreatmentConditionIds = from c in db.TreatmentConditions
                                                where inputFactors.Contains(c.TreatmentFactorID)
                                                where c.IsComposed
                                                select c;
            char[] delimiterChars = { ',' };
            foreach (TreatmentCondition c in composedTreatmentConditionIds)
            {
                string[] strValues = c.FactorValue.Split(delimiterChars);
                int intValue;
                bool isMatched = false;
                foreach (string s in strValues)
                {
                    bool parsed = Int32.TryParse(s, out intValue);
                    if (parsed && txConditionIds.Contains(intValue))
                    {
                        isMatched = true;
                    }
                }
                if (isMatched)
                {
                    composedConditionIds.Add(c.TreatmentConditionID);
                    //logger.Debug("found composed condition: " + c.TreatmentConditionID);
                }
            }
            return composedConditionIds;
        }
        //
        private HashSet<int> FindExludedTreatmentConditionIds(HashSet<int> txFactorIds, HashSet<int> txConditionIds)
        {
            var excludedTreatmentConditionIds = from d in db.TreatmentConditions
                                                from c in db.TreatmentFactors
                                                where d.TreatmentFactorID == c.TreatmentFactorID
                                                where txFactorIds.Contains(c.TreatmentFactorID)
                                                where txConditionIds.Contains(d.TreatmentConditionID) == false
                                                select d.TreatmentConditionID;
            var excludedConditionIds = new HashSet<int>(excludedTreatmentConditionIds);
            return excludedConditionIds;
        }
        //
        private TreatmentFactor FindTreatmentFactor(int treatmentConditionId)
        {
            //var nextFactor = from factor in db.TreatmentFactors
            //                from condition in db.TreatmentConditions
            //                where factor.TreatmentFactorID == condition.TreatmentFactorID
            //               select factor;
            var factor = db.TreatmentFactors
                .Where(s => s.TreatmentConditions.Select(d => d.TreatmentConditionID).Contains(treatmentConditionId))
                .Single();

            //logger.Debug("FindTreatmentFactor=" + factor.FactorName);
            return factor;
        }
        //
        private List<DiseaseTreatmentIndication> GetTreatmentIndications(int diseaseId)
        {
            return db.DiseaseTreatmentIndications
                .Where(x => x.DiseaseID == diseaseId)
                .OrderBy(f => f.Order)
                .ToList();
        }
        //
        private List<DiseaseTreatmentFactorViewData> GetTreatmentFactorViewDataList(List<DiseaseTreatmentFactorViewData> inputFactors)
        {
            List<DiseaseTreatmentFactorViewData> oFactorList = new List<DiseaseTreatmentFactorViewData>();
            foreach (var iFactor in inputFactors)
            {
                var tf = db.TreatmentFactors.Find(iFactor.FactorID);
                DiseaseTreatmentFactorViewData oFactor = new DiseaseTreatmentFactorViewData();
                oFactor.FactorID = tf.TreatmentFactorID;
                oFactor.Prompt = tf.PatientPrompt;
                oFactor.Conditions = new List<TreatmentConditionViewData>();

                foreach (var tc in tf.TreatmentConditions)
                {
                    if (tc.IsComposed == false)
                    {
                        oFactor.Conditions.Add(new TreatmentConditionViewData()
                        {
                            ConditionID = tc.TreatmentConditionID,
                            Value = tc.FactorValue,
                            IsSelected = iFactor.SelectedTreatmentConditionID.Contains(tc.TreatmentConditionID) ? true : false
                        });
                    }
                }
                oFactorList.Add(oFactor);
            }
            return oFactorList;
        }
        //
        private HashSet<int> GetTreatmentFactorIds(HashSet<int> conditionIds)
        {
            var fco = (from f in db.TreatmentFactors
                       from c in db.TreatmentConditions
                       where f.TreatmentFactorID == c.TreatmentFactorID
                       where conditionIds.Contains(c.TreatmentConditionID)
                       select f.TreatmentFactorID).Distinct();
            return new HashSet<int>(fco);
        }
        //
        private DiseaseTreatmentFactorViewData CreateDiseaseTreatmentFactorViewData(TreatmentFactor factor)
        {
            DiseaseTreatmentFactorViewData diseaseTxFactor = new DiseaseTreatmentFactorViewData();
            diseaseTxFactor.FactorID = factor.TreatmentFactorID;
            diseaseTxFactor.Prompt = factor.PatientPrompt;
            diseaseTxFactor.Category = factor.FactorCategory.ToString();
            diseaseTxFactor.Conditions = new List<TreatmentConditionViewData>();
            foreach (var c in factor.TreatmentConditions)
            {
                if (!c.IsComposed)
                {
                    TreatmentConditionViewData conditionViewData = new TreatmentConditionViewData();
                    conditionViewData.ConditionID = c.TreatmentConditionID;
                    conditionViewData.Value = c.FactorValue;
                    conditionViewData.IsSelected = false;


                    diseaseTxFactor.Conditions.Add(conditionViewData);
                }
            }
            return diseaseTxFactor;
        }
    }
}