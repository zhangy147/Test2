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
    public class MedicalRecordManager
    {
        static MedicalRecordManager medicalRecordManager;
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MedicalRecordManager()
        {
        }

        public static MedicalRecordManager Instance
        {
            get
            {
                if (medicalRecordManager == null)
                {
                    medicalRecordManager = new MedicalRecordManager();
                }
                return medicalRecordManager;
            }
        }
        //
        //
        private List<RequiredMedicalRecord> GetRequiredMedicalRecords(int diseaseId)
        {
            List<RequiredMedicalRecord> mRecords = db.RequiredMedicalRecords
              .Include(s => s.DiseaseRecord)
              .Include(s => s.DiseaseRecord.MedicalRecord)
              .Where(d => d.DiseaseRecord.DiseaseID == diseaseId)
              .ToList();
            return mRecords;
        }
        //
        private List<PatientMedicalRecord> GetPatientMedicalRecords(int pProfileId)
        {
            var patientRecords = db.PatientMedicalRecords
            .Include(s => s.RequiredRecord)
            .Include(s => s.RequiredRecord.DiseaseRecord)
            .Include(s => s.RequiredRecord.DiseaseRecord.MedicalRecord)
            .Where(s => s.PatientProfileID == pProfileId)
            .OrderBy(d => d.RequiredRecord.DiseaseRecord.MedicalRecord.Name)
            .ToList();

            return patientRecords;
        }

        //
        public List<RequiredMedicalRecordViewData> GetRequiredMedicalRecordViewDataList(int diseaseId)
        {
            List<RequiredMedicalRecordViewData> mRecordsViewData = new List<RequiredMedicalRecordViewData>();
            List<RequiredMedicalRecord> mRecords = GetRequiredMedicalRecords(diseaseId);
            foreach (var mr in mRecords)
            {
                RequiredMedicalRecordViewData recordVD = new RequiredMedicalRecordViewData();
                recordVD.RecordID = mr.DiseaseRecord.MedicalRecord.MedicalRecordID;
                recordVD.RecordName = mr.DiseaseRecord.MedicalRecord.Name;
                recordVD.RecordDesc = mr.DiseaseRecord.MedicalRecord.Desc;
                recordVD.IsMandatory = mr.DiseaseRecord.IsMandatory;
                mRecordsViewData.Add(recordVD);
            }
            return mRecordsViewData;
        }

        //
        public List<UploadedMedicalRecordViewData> GetUploadedMedicalRecordViewDataList(int pProfileId)
        {
            List<UploadedMedicalRecordViewData> uploaded = new List<UploadedMedicalRecordViewData>();

            List<PatientMedicalRecord> patientRecords = GetPatientMedicalRecords(pProfileId);
            foreach (var record in patientRecords)
            {
                UploadedMedicalRecordViewData recordVD = new UploadedMedicalRecordViewData();
                recordVD.RecordID = record.RequiredRecord.DiseaseRecord.MedicalRecord.MedicalRecordID;
                recordVD.RecordName = record.RequiredRecord.DiseaseRecord.MedicalRecord.Name;
                recordVD.FileName = record.FileName;
                uploaded.Add(recordVD);
            }
            return uploaded;
        }
        //
        public SelectList GetUnuploadedMedicalRecordsSelectList(int profileId, int diseaseId)
        {
            List<RequiredMedicalRecordViewData> mRecordsViewData = new List<RequiredMedicalRecordViewData>();
            //
            var mRecords = GetRequiredMedicalRecords(diseaseId);
            
            var uploadedRecords = GetPatientMedicalRecords(profileId);
            var uploadedRecordsIds = new HashSet<int>();
            if (uploadedRecords.Count > 0)
            {
                uploadedRecordsIds = new HashSet<int>(uploadedRecords.Select(s => s.RequiredRecord.DiseaseRecord.MedicalRecordID));
            }
            
            foreach (var mR in mRecords)
            {
                if (!uploadedRecordsIds.Contains(mR.DiseaseRecord.MedicalRecordID))
                {
                    mRecordsViewData.Add(
                        new RequiredMedicalRecordViewData()
                        {
                            RecordID = mR.DiseaseRecord.MedicalRecordID,
                            IsMandatory = mR.DiseaseRecord.IsMandatory,
                            RecordName = mR.DiseaseRecord.MedicalRecord.Name,
                            RecordDesc = mR.DiseaseRecord.MedicalRecord.Desc
                        });
                }
            }
            return new SelectList(mRecordsViewData, "RecordID", "RecordName", null);
        }
        //=================================  END of Medical Record =====================================
    }
}