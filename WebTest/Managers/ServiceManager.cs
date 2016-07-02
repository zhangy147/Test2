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
    public class ServiceManager
    {
        static ServiceManager serviceManager;
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ServiceManager()
        {
        }

        public static ServiceManager Instance
        {
            get
            {
                if (serviceManager == null)
                {
                    serviceManager = new ServiceManager();
                }
                return serviceManager;
            }
        }

        public List<CreditCardType> getCreditCardTypes()
        {
            List<CreditCardType> cardTypes = Enum.GetValues(typeof(CreditCardType)).Cast<CreditCardType>().Select(v => v).ToList();

            return cardTypes;
        }

        public SelectList getMonths()
        {
            List<SelectListItem> ml = new List<SelectListItem>();
            ml.Add(new SelectListItem() { Selected = true, Text = "[Month]", Value = "0" });
            for(int m =1 ; m <= 12;  m++) {
                 ml.Add(new SelectListItem(){ Selected= false, Text = m.ToString(), Value = m.ToString() });
            }

            SelectList monthList = new SelectList(ml, "Value" , "Text");
            return monthList;
        }
    }
}