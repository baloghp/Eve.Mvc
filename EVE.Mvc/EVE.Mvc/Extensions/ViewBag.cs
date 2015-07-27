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
            documentHelper.ProcessNodesWithAttribute(ViewBagAttribute, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Styles.Render(a.Attributes[ViewBagAttribute].Value);
                        return value.ToHtmlString();
                    }
               ));


            return documentHelper;
        }
    }
}
