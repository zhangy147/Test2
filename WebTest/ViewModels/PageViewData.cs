using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.ViewModels
{
    public class PageViewData
    {
        public bool WasSubmitted { get; set; }
        public bool WasSaved { get; set; }
        public string CurrentPage { get; set; }
        public string NextPage { get; set; }
    }
}