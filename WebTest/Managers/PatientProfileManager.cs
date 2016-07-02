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
    public class PatientProfileManager : BaseController
    {
        static PatientProfileManager profileManager;
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PatientProfileManager()
        {
        }

        public static PatientProfileManager Instance
        {
            get
            {
                if (profileManager == null)
                {
                    profileManager = new PatientProfileManager();
                }
                return profileManager;
            }
        }
        //

        //
        public List<DiseaseTreatmentFactorViewData> GetDiseaseTreatmentFactorsViewData(int diseaseId)
        {
            List<DiseaseTreatmentFactorViewData> factorsViewData = new List<DiseaseTreatmentFactorViewData>();
            var allFactors = from dFactor in db.DiseaseTreatmentFactors
                                 from tFactor in db.TreatmentFactors
                                 from tCondition in db.TreatmentConditions
                                 where dFactor.TreatmentFactorID == tFactor.TreatmentFactorID
                                 where tFactor.TreatmentFactorID == tCondition.TreatmentFactorID
                                 where dFactor.DiseaseID == diseaseId
                                 select new { 
                                     tFactor, 
                                     dFactor.DependentFactorID, 
                                     dFactor.DependentConditionID, 
                                     dFactor.Order };
            //logger.Debug("[GetDiseaseTreatmentFactorsViewData]all factors: " + allFactors.Count());

            foreach (var element in allFactors.Distinct())
            {
                DiseaseTreatmentFactorViewData fViewData = new DiseaseTreatmentFactorViewData()
                {
                    FactorID = element.tFactor.TreatmentFactorID,
                    Prompt = element.tFactor.PatientPrompt,
                    Category = element.tFactor.FactorCategory.ToString(),
                    DependentFactorID = element.DependentFactorID,
                    DependentConditionIds = element.DependentConditionID,
                    Order = element.Order,
                    IsLast = false,
                    Conditions = new List<TreatmentConditionViewData>()
                };

                foreach (var d in element.tFactor.TreatmentConditions)
                {

                    //logger.Debug("factor: " + element.tFactor.FactorName);
                    //logger.Debug("condtions: " + d.TreatmentConditionID + ",  isComposed=" + d.IsComposed.ToString());
                   
                    TreatmentConditionViewData cViewData = new TreatmentConditionViewData()
                    {
                        ConditionID = d.TreatmentConditionID,
                        Value = d.FactorValue,
                        IsComposed = d.IsComposed,
                        IsSelected = false
                    };
                    fViewData.Conditions.Add(cViewData);
                };
                factorsViewData.Add(fViewData);

            }
            return factorsViewData;
        }
        //

        //
        public List<DiseaseTreatmentFactorViewData> GetInitialTreatmentFactors(int diseaseId)
        {
            List<DiseaseTreatmentFactorViewData> dList = GetDiseaseTreatmentFactorsViewData(diseaseId);
            var initialFactors = dList
                .Where(d => d.DependentFactorID == 0)
                .Where(s => s.Category == TreatmentFactorCategory.DiseaseDynamicState.ToString())
                .OrderBy(o => o.Order).ToList();
            return initialFactors;
        }

        //
        //public List<DiseaseTreatmentFactorViewData> GetDiseaseTreatmentFactorsViewData(HashSet<int> inputFactorIds, HashSet<int> inputConditionIds, int category)
        //{
        //    int diseaseId = 4;
        //    List<DiseaseTreatmentFactorViewData> dList = GetDiseaseTreatmentFactorsViewData(diseaseId);
        //    List<DiseaseTreatmentFactorViewData> returnList = new List<DiseaseTreatmentFactorViewData>();
        //    //
        //    List<DiseaseTreatmentFactorViewData> stateFactors = null;
        //    //
        //    if (category == 1)
        //    {
        //        stateFactors = (from d in dList
        //                        where inputFactorIds.Contains(d.DependentFactorID)
        //                        where d.Category != TreatmentFactorCategory.PatientFeasibility.ToString() &&
        //                        d.Category != TreatmentFactorCategory.OtherSupport.ToString()
        //                        orderby d.Order
        //                        select d).ToList();
        //    }
        //    else if (category == 2)
        //    {
        //        inputFactorIds.Add(1);
        //        inputFactorIds.Add(16);
        //        inputConditionIds.Add(23);
        //        inputConditionIds.Add(1);
        //        //
        //        stateFactors = (from d in dList
        //                        where inputFactorIds.Contains(d.DependentFactorID)
        //                        where d.Category == TreatmentFactorCategory.PatientFeasibility.ToString() ||
        //                        d.Category == TreatmentFactorCategory.OtherSupport.ToString()
        //                        orderby d.Order
        //                        select d).ToList();
        //    }
            
        //    //
        //    char[] delimiterChars = { ',' };
        //    if (stateFactors != null)
        //    {
        //        foreach (var f in stateFactors)
        //        {
        //            string[] strValues = f.DependentConditionIds.Split(delimiterChars);
        //            int intValue;
        //            //bool isMatched = false;
        //            foreach (string s in strValues)
        //            {
        //                bool parsed = Int32.TryParse(s, out intValue);
        //                if (parsed && inputConditionIds.Contains(intValue))
        //                {
        //                    //isMatched = true;
        //                    returnList.Add(f);
        //                }
        //            }
        //        }

        //    }
        //    return returnList;
        //}
        public List<DiseaseTreatmentFactorViewData> GetNextDiseaseTreatmentFactorsViewData(int diseaseId, HashSet<int> inputConditionIds, int category)
        {
            List<DiseaseTreatmentFactorViewData> dList = GetDiseaseTreatmentFactorsViewData(diseaseId);
            List<DiseaseTreatmentFactorViewData> returnList = new List<DiseaseTreatmentFactorViewData>();
            //
            List<DiseaseTreatmentFactorViewData> stateFactors = null;
            //
            if (category == 1)
            {
                stateFactors = (from d in dList
                                where d.Category != TreatmentFactorCategory.PatientFeasibility.ToString() &&
                                d.Category != TreatmentFactorCategory.OtherSupport.ToString()
                                orderby d.Order
                                select d).ToList();
            }
            else if (category == 2)
            {
                inputConditionIds.Add(23);
                inputConditionIds.Add(1);
                //
                stateFactors = (from d in dList
                                where d.Category == TreatmentFactorCategory.PatientFeasibility.ToString() ||
                                d.Category == TreatmentFactorCategory.OtherSupport.ToString()
                                orderby d.Order
                                select d).ToList();
            }

            //
            char[] delimiterChars = { ',' };
            if (stateFactors != null)
            {
                foreach (var f in stateFactors)
                {
                    string[] strValues = f.DependentConditionIds.Split(delimiterChars);
                    int intValue;
                    //bool isMatched = false;
                    foreach (string s in strValues)
                    {
                        bool parsed = Int32.TryParse(s, out intValue);
                        if (parsed && inputConditionIds.Contains(intValue))
                        {
                            //isMatched = true;
                            returnList.Add(f);
                        }
                    }
                }

            }
            return returnList;
        }
        //
        //public DiseaseTreatmentFactorViewData CreateDiseaseTreatmentFactorViewData(TreatmentFactor factor)
        //{
        //    DiseaseTreatmentFactorViewData diseaseTxFactor = new DiseaseTreatmentFactorViewData();
        //    diseaseTxFactor.FactorID = factor.TreatmentFactorID;
        //    diseaseTxFactor.Prompt = factor.PatientPrompt;
        //    diseaseTxFactor.Category = factor.FactorCategory.ToString();

        //    diseaseTxFactor.Conditions = new List<TreatmentConditionViewData>();
        //    foreach (var c in factor.TreatmentConditions)
        //    {
        //        if (!c.IsComposed)
        //        {
        //            TreatmentConditionViewData conditionViewData = new TreatmentConditionViewData();
        //            conditionViewData.ConditionID = c.TreatmentConditionID;
        //            conditionViewData.Value = c.FactorValue;
        //            conditionViewData.IsSelected = false;
        //            diseaseTxFactor.Conditions.Add(conditionViewData);
        //        }
        //    }
        //    return diseaseTxFactor;
        //}
        //
        public List<DiseaseProcedureViewData> GetEvaluationProcedures(int? diseaseId)
        {
            List<DiseaseProcedureViewData> proceduresViewData = new List<DiseaseProcedureViewData>();

            if (diseaseId == null)
            {
                return new List<DiseaseProcedureViewData>();
            }
            var dProcedures = from p in db.DiseaseProcedures
                              where p.DiseaseID == diseaseId
                              orderby p.Procedure.Name
                              select p;
            foreach (var p in dProcedures)
            {
                DiseaseProcedureViewData dvd = new DiseaseProcedureViewData();
                dvd.ProcedureID = p.Procedure.ProcedureID;
                dvd.Name = p.Procedure.Name;
                dvd.Desc = p.Procedure.Desc;
                dvd.IsReceived = false;
                //
                proceduresViewData.Add(dvd);
            }
            //logger.Debug("size of procedures: " + proceduresViewData.Count);
            //
            return proceduresViewData;
        }

    }
}