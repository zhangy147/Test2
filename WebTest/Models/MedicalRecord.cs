using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace WebTest.Models
{
   
    public class MedicalRecord
    {
        public int MedicalRecordID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
    }

    public class DiseaseMedicalRecord
    {
        public int DiseaseMedicalRecordID { get; set; }
        public int DiseaseID { get; set; }
        public int MedicalRecordID { get; set; }
        public bool IsMandatory { get; set; }
        //
        public virtual MedicalRecord MedicalRecord { get; set; }
    }

    public class RequiredMedicalRecord
    {
        public int RequiredMedicalRecordID { get; set; }
        public int UserGroupID { get; set; }
        public int DiseaseMedicalRecordID { get; set; }
        //
        public virtual DiseaseMedicalRecord DiseaseRecord { get; set; }
    }

    public class PatientMedicalRecord
    {
        [Key]
        public int PatientMedicalRecordID { get; set; }
        public int PatientProfileID { get; set; }
        public int RequiredMedicalRecordID { get; set; }
        public DateTime DateReceived { get; set; }
        public string HospitalReceived { get; set; }
        public string PatientNotes { get; set; }
        //
        public string FileName { get; set; }
        public string FileType { get; set; }
        //
        //the following line will block the creation of database - don't know why
        //public HttpPostedFileBase File { get; set; }
        public DateTime UploadDate { get; set; }
        //
        public string InternalCode { get; set; }
        public string FileLocation { get; set; }
        public bool IsUploadedByUser { get; set; }
        //
        public virtual RequiredMedicalRecord RequiredRecord { get; set; }
        public virtual PatientProfile Patient { get; set; }
    }
}