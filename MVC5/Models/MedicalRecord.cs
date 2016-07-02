using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;

namespace MVC5.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public int ProcedureID { get; set; }
        public bool IsMandatory { get; set; }
    }

    public class PatientMedicalRecord
    {
        [Key]
        public int PatientMedicalRecordID { get; set; }
        public int PatientProfileID { get; set; }
        public int MedicalRecordID { get; set; }
        public DateTime DatePerformed { get; set; }
        public string HospitalPerformed { get; set; }
        public string UserNotes { get; set; }
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
    }
}