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
    /// Extension method to handle Bundles (script and style both)
    /// </summary>
    public static class Bundles
    {
        public const string Scripts = "eve-scripts";
        public const string Styles = "eve-styles";

        //TODO: should make this work with comma separated list of values

        /// <summary>
        ///  Processes the html document's tags with Scripts and Styles ("eve-scripts", "eve-styles") attributes, 
        /// by evaluating the given attribute value from script or style bundles, and inserting the result to the tag.
        /// </summary>
        /// <param name="documentHelper">Document to attach this functionality on</param>
        /// <returns></returns>
        public static IDocumentHelper ProcessBundles(this IDocumentHelper documentHelper)
        {
            //Sequential processing is required because the evaluation needs the http context that 
            // parallel implementation does not have on all threads
            documentHelper.ProcessNodesWithAttributeSequential(Styles, new Func<HtmlNode, string>(a =>
                    {
                        var value = System.Web.Optimization.Styles.Render(a.Attributes[Styles].Value);
                         return value.ToHtmlString();
                    }
                ));
            //Sequential processing is required because the evaluation needs the http context that 
            // parallel implementation does not have on all threads
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
