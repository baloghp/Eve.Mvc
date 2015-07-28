using Dynamitey;
using EVE.Mvc.ViewEngine;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{
    public static class ViewBag
    {
        public const string ViewBagAttribute = "eve-viewbag";
        public static IDocumentHelper ProcessViewBag(this IDocumentHelper documentHelper, ViewContext viewContext)
        {
            documentHelper.ProcessNodesWithAttributeSequential(ViewBagAttribute, new Func<HtmlNode, string>(a =>
                    {
                        var dynaPath = a.Attributes[ViewBagAttribute].Value;
                        var value = Dynamic.InvokeGet(viewContext.ViewBag,dynaPath);
                        return value.ToString();
                    }
               ));
            return documentHelper;
        }
    }
}
