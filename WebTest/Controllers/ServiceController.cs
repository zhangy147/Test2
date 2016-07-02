using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;  //for HttpStatusCodeResult
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Data;
using System.Data.Entity;

using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;

namespace WebTest.Controllers
{
    public class ServiceController : Controller
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult GetServiceSummary()
        {
            logger.Debug("GetServiceSummary");

            List<ServiceViewData> serviceVDList = new List<ServiceViewData>();
            ServiceViewData serviceVD = new ServiceViewData();
            serviceVD.ServiceID = 3;
            serviceVD.ServiceName = "Best Treatment Report";
            serviceVD.ProviderID = 1;
            serviceVD.ProviderName = "EBM Reasearch & Spread";
            serviceVD.Price = 120;
            serviceVD.CurrencySymble = "$";
            serviceVD.CurrencyText = "US Dollar";
            serviceVDList.Add(serviceVD);

            logger.Debug("serviceVDList Created");
            return PartialView("_ServiceSummaryTab", serviceVDList);
        }


        [HttpGet]
        public ActionResult CollectPayment()
        {
            logger.Debug("CollectPayment");
            ViewBag.CardTypes = ServiceManager.Instance.getCreditCardTypes();
            ViewBag.MonthList = ServiceManager.Instance.getMonths();
            ServiceOrderViewData sOrder = new ServiceOrderViewData();
            return PartialView("_PaymentInformationTab", sOrder);
        }


        [HttpPost]
        public ActionResult SavePayment(ServiceOrderViewData sOrder)
        {
            logger.Debug("SavePayment called");
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "ServiceCenter");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + dex);
            }
            return RedirectToAction("CollectPayment", sOrder);
        }
    }
}