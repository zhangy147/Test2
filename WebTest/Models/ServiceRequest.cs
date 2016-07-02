using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;


namespace WebTest.Models
{
    //one order may have more services
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }
        public string ConfirmationCode {get; set;}
        public int UserID { get; set; }
        public int PatientProfileID { get; set; }
        public int DiseaseID { get; set; }
       
        public DateTime InsertDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public DateTime CloseDate { get; set; }

        public virtual ICollection<ServiceOrderDetail> OrderDetails { get; set; }
    }

    //one order may ask many services
    public class ServiceOrderDetail
    {
        public int ServiceOrderDetailID { get; set; }
        public int ServiceOrderID { get; set; }
        public int ServiceProviderID { get; set; }
    }

    //one service may be provided by many providers
    public class Service
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceName_ZH { get; set; }
        public string ServiceDesc { get; set; }
        public string ServiceDesc_ZH { get; set; }
        public bool AllowChooseProvider { get; set; }
        //
        public virtual ICollection<Provider> Providers { get; set; }
    }

    //one provider may provide many services
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderName_ZH { get; set; }
        //public Address Address { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }

     public enum AccepatingCurrency
    {
        USDollar = 1, ChinaYuan = 2
    }


    public class ServiceProvider
    {
        [Key]
        public int ServiceProviderID { get; set; }
        public int ServiceID { get; set; }
        public int ProviderID { get; set; }
        public float Price { get; set; }
        public AccepatingCurrency AccepatingCurrency { get; set; } 
    }

    public class ServiceReport
    {
        [Key]
        public int ReportID { get; set; }
        public int ServiceOrderID { get; set; }
        public string ReportName { get; set; }
        public string InternalCode { get; set; }
        public string Location { get; set; }
        public DateTime ReleaseDateTime { get; set; }
    }

    public class BillingInfo
    {
        [Key]
        public int BillingInfoID { get; set; }
        public int UserID { get; set; }
   
        public string BillingLastName { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillinZipcode { get; set; }
        public string BillingCountry { get; set; }
    }

    public enum CreditCardType
    {
        Visa = 1, MasterCard = 2, AmericanExpress = 3, Discovery = 4
    }

    public class CreditCard
    {
        [Key]
        public int CrediCardID { get; set; }
        public CreditCardType CardType { get; set; }
        public string AccountNumber { get; set; }
        public string CVVCode { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }

    //one payment for one order
    //one order may have more services
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int ServiceOrderID { get; set; }
        public string ConfirmationCode { get; set; }
        public int BillingInfoID { get; set; }
        public int CreditCardID { get; set; }
        public float ChargeAmount { get; set; }
        public string CurrencyCode { get; set; }

        public string TransactionCode { get; set; } 
        public DateTime TransactionDateTime { get; set; }

        public virtual ServiceOrder ServiceOrder { get; set; }
    }
}