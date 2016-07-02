using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;  //for HttpStatusCodeResult
using System.Data.Entity.Infrastructure;  //for RetryLimitExceededException
using System.Data;
using System.Data.Entity;
//
using System.Diagnostics;
using System.IO;
//using PdfSharp;
//using PdfSharp.Drawing;
using PdfSharp.Pdf;
//using PdfSharp.Pdf.IO;
//
using WebTest.Models;
using WebTest.ViewModels;
using WebTest.DAL;
using WebTest.Helpers;
using WebTest.Managers;


namespace WebTest.Controllers
{
    public class ServiceCenterController : BaseController
    {
        private SiteDbContext db = new SiteDbContext();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: ServiceCenter
        public ActionResult Index()
        {
            int profileId = GetCurrentPatientProfileID();
            int diseaseId = GetCurrentDiseaseID();
            if (profileId > 0 && diseaseId > 0)
            { 
            }
            return View();
        }

        public PartialViewResult GetPDFPartialView()
        {
            return PartialView("_PDFReport");
        }

        [HttpGet]
        public PartialViewResult AskQuestion()
        {
            PatientQuestionViewData questionVD = new PatientQuestionViewData();
            return PartialView("_AskQuestion", questionVD);
        }
        
        [HttpPost]
        public PartialViewResult SaveQuestion()
        {
            int profileId = 1;
            var qaList = db.PatientQuestions
                .Where(s => s.PatientProfileID == profileId)
                .OrderBy(s => s.DateAsked).ToList();




            return PartialView("_QuestionAndAnswer", qaList);
        }
        //public FileResult DisplayPDF()
        //{
        //    return File("/Files/PDF/sample_colon_ca.pdf", "application/pdf");
        //}

        public FileResult DisplayPDF()
        {
            string filepath = Server.MapPath("/Files/PDF/sample_colon_ca.pdf");
            byte[] pdfByte = PDFHelper.GetBytesFromFile(filepath);
            return File(pdfByte, "application/pdf");
        }

        public FileResult CreatePdfOnFly()
        {
            MemoryStream stream = new MemoryStream();
            PdfDocument doc = PDFHelper.CreatePdfDoc("");
            stream.Position = 0;

            doc.Save(stream, false);
            Response.Clear();

            //Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            //Response.Flush();
            //stream.Close();
            //Response.End();
            return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
    }
}