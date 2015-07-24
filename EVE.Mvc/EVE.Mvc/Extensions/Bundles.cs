using EVE.Mvc.ViewEngine;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EVE.Mvc;

namespace EVE.Mvc
{
    public static class Bundles
    {
        public const string Scripts = "eve-scripts";
        public const string Styles = "eve-styles";
        public static IDocumentHelper ProcessBundles(this IDocumentHelper documentHelper)
        {
            documentHelper.ProcessNodesWithAttribute(Styles, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Styles.Render(a.Attributes[Styles].Value);
                        return value.ToHtmlString();
                    }
                ));

            documentHelper.ProcessNodesWithAttribute(Scripts, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Scripts.Render(a.Attributes[Scripts].Value);
                        return value.ToHtmlString();
                    }
                ));



            return documentHelper;
        }


    }
}
