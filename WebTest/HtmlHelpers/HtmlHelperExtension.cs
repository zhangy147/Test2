using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebTest.ViewModels;

namespace WebTest.HtmlHelpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression, string htmlFieldName = null) where TModel : class
        {
            var items = expression.Compile()(html.ViewData.Model);
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(htmlFieldName))
            {
                var prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;

                htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
            }

            foreach (var item in items)
            {
                var dummy = new { Item = item };
                var guid = Guid.NewGuid().ToString();

                var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
                var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);

                sb.Append(String.Format(@"<input type=""hidden"" name=""{0}.Index"" value=""{1}"" />", htmlFieldName, guid));
                //sb.Append(String.Format(@"<input type=""hidden"" name=""Index"" value=""{0}"" />", guid));
                sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", htmlFieldName, guid)));
            }

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString EditorForTreatmentFactorViewDataList(this HtmlHelper helper, List<DiseaseTreatmentFactorViewData> factors) 
        {
            TagBuilder outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("form-group");
            //
            int guid = 0;
            foreach (var factor in factors)
            {
                //var guid = factor.FactorID.ToString();
                //
                var controlGroup = new TagBuilder("div");
                var hiddenFactorID = new TagBuilder("input");
                hiddenFactorID.Attributes.Add("type", "hidden");
                hiddenFactorID.Attributes.Add("name", String.Format("[{0}].FactorID", guid));
                hiddenFactorID.Attributes.Add("value", factor.FactorID.ToString());
                //
                var labelPrompt = new TagBuilder("label");
                labelPrompt.AddCssClass("control-label");
                labelPrompt.InnerHtml = factor.Prompt;
                //
                //controlGroup.InnerHtml += hiddenIndex;
                controlGroup.InnerHtml += hiddenFactorID;
                controlGroup.InnerHtml += labelPrompt;
                //
                foreach (var c in factor.Conditions)
                {
                    if (c.IsComposed == false)
                    {
                        var radioDiv = new TagBuilder("div");
                        radioDiv.AddCssClass("radio");
                        //
                        var radioTag = new TagBuilder("input");
                        radioTag.Attributes.Add("type", "radio");
                        radioTag.Attributes.Add("name", String.Format("[{0}].SelectedTreatmentConditionID", guid));
                        radioTag.Attributes.Add("value", c.ConditionID.ToString());
                        if (c.IsSelected)
                        {
                            radioTag.Attributes.Add("checked", "checked");
                        }
                        //
                        var radioLabel = new TagBuilder("label");
                        radioLabel.InnerHtml = c.Value;
                        //
                        radioDiv.InnerHtml += radioTag;
                        radioDiv.InnerHtml += radioLabel;
                        //
                        controlGroup.InnerHtml += radioDiv;
                    }
                }
                outerDiv.InnerHtml += controlGroup;
                //
                guid++;
            }
            return new MvcHtmlString(outerDiv.ToString());
        }


    }
}