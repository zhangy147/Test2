using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC5.Helpers
{
    public class ControllerHelper
    {
        public static string getModelStateErrors(ModelStateDictionary modelState)
        {
            String errors = String.Join(Environment.NewLine, modelState.Values.SelectMany(v => v.Errors)
                                                           .Select(v => v.ErrorMessage + " " + v.Exception));
            return errors;
        }
    }
}