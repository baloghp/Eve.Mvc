using EVE.Mvc.ViewEngine;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace EVE.Mvc
{
    public static class DataBinding
    {
        public const string EvalAttribute = "eve-eval";

        public static IDocumentHelper ProcessEvals(this IDocumentHelper documentHelper, object Model)
        {

            documentHelper.ProcessNodesWithAttribute(EvalAttribute, new Func<HtmlNode, string>(a =>
            {
                var evalPath = a.Attributes[EvalAttribute].Value;
                //eval the new partial model on the current one
                if (Model != null && !string.IsNullOrWhiteSpace(evalPath))
                {
                    var evalValue = DataBinder.Eval(Model, evalPath);
                   return evalValue == null ? string.Empty : evalValue.ToString();
                }
                return null;
            }
               ));


            return documentHelper;
        }
    }
}
