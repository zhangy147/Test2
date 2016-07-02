using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;


namespace MVC5.Models
{
    public class ConsultingService
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceName_ZH { get; set; }
        public string ServiceDesc { get; set; }
        public string ServiceDesc_ZH { get; set; }
        public bool AllowChooseProvider { get; set; }
    }
    public class ServiceProvider
    {
        [Key]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderName_ZH { get; set; }
        //public Address Address { get; set; }
        public virtual ICollection<ConsultingService> ConsultingServices { get; set; }
    }

    public class ServiceReport
    {
        [Key]
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string InternalCode { get; set; }
        public string LinkToFile { get; set; }
        public DateTime? ReleaseDateTime { get; set; }
    }

    public class RequestedService
    {
        [Key]
        public int RequestedServiceID { get; set; }
        public int PatientProfileID { get; set; }

        [Display(Name = "Service")]
        public int ServiceID { get; set; }

        [Display(Name = "Service provider")]
        public int ProviderID { get; set; }
        public int ServiceReportID { get; set; }
        public DateTime? InsertDate { get; set; }
        public virtual ConsultingService Service { get; set; }
        public virtual ServiceProvider Provider { get; set; }
        public virtual ServiceReport Report { get; set; }
    }
}