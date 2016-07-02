using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebTest.ViewModels
{
    public class PatientQuestionViewData
    {
        [Required]
     
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
    }
}