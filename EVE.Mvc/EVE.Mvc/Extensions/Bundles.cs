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
    /// <summary>
    /// Extesnion method to handle Bundles (script and style both)
    /// </summary>
    public static class Bundles
    {
        public const string Scripts = "eve-scripts";
        public const string Styles = "eve-styles";

        //TODO: should make this work with comma separated list of values
        public static IDocumentHelper ProcessBundles(this IDocumentHelper documentHelper)
        {
            documentHelper.ProcessNodesWithAttributeSequential(Styles, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Styles.Render(a.Attributes[Styles].Value);
                         return value.ToHtmlString();
                    }
                ));

            documentHelper.ProcessNodesWithAttributeSequential(Scripts, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Scripts.Render(a.Attributes[Scripts].Value);
                        return value.ToHtmlString();
                    }
                ));



            return documentHelper;
        }


    }
}
