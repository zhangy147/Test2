using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTest.HtmlHelpers
{
    public static class ImageLinkHelper
    {
        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imgSrc, string alt, string actionName, string controllerName, object routeValues, Object htmlAttributes, Object imgHtmlAttributes)
        {
            UrlHelper urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
            var imgTag = new TagBuilder("img");
            imgTag.MergeAttribute("src", imgSrc);
            //
            //this line is a bug below
            //imgTag.MergeAttributes((IDictionary<string, string>)imgHtmlAttributes, true);
            imgTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(imgHtmlAttributes));
            string url = urlHelper.Action(actionName, controllerName, routeValues);



            var imglink = new TagBuilder("a");
            imglink.MergeAttribute("href", url);
            imglink.InnerHtml = imgTag.ToString();
            //imglink.MergeAttributes((IDictionary<string, string>)htmlAttributes, true);
            imglink.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(imglink.ToString());

        }
    }
}