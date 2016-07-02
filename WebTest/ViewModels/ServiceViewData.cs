using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlobalResources;
using WebTest.Models;


namespace WebTest.ViewModels
{
    public class ServiceOrderViewData
    {
        public int ServiceOrderID { get; set; }

        [Display(Name = "Last Name")]
        public string BillingLastName { get; set; }
        [Display(Name = "First Name")]
        public string BillingFirstName { get; set; }

        [Display(Name = "Address")]
        public string BillingAddress { get; set; }

        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [Display(Name = "State/Province")]
        public string BillingState { get; set; }

        [Display(Name = "Zip/Postal Code")]
        public string BillinZipcode { get; set; }

        [Display(Name = "Country")]
        public string BillingCountry { get; set; }

        [Display(Name = "Type of Credit Card")]
        public CreditCardType CardType { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "CVV Code")]
        public string CVVCode { get; set; }

        [Display(Name = "Expiration Month")]
        public int ExpirationMonth { get; set; }

        [Display(Name = "Year")]
        public int ExpirationYear { get; set; }

        //public List<ServiceViewData> Services { get; set; }
    }


    public class ServiceViewData
    {
        public int ServiceID { get; set; }

        [Display(Name = "Servie")]
        public string ServiceName { get; set; }

       
        public int ProviderID { get; set; }

        [Display(Name = "Provider")]
        public string ProviderName { get; set; }

        [Display(Name = "Price")]
        public float Price { get; set; }
        
        public string CurrencySymble { get; set; }

        public string CurrencyText { get; set; }

    }
}