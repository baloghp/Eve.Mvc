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
        /// <summary>
        /// Processes the html document's tags with ViewBagAttribute ("eve-viewbag") attributes, 
        /// by evaluating the given attribute value on the given viewContext's viewbag, and inserting the result into the tag.
        /// </summary>
        /// <param name="documentHelper">Document this extension is attached on</param>
        /// <param name="viewContext">ViewContext of the ViewBag</param>
        /// <returns></returns>
        public static IDocumentHelper ProcessViewBag(this IDocumentHelper documentHelper, ViewContext viewContext)
        {
            if (viewContext == null)
                throw new ArgumentNullException("viewContext");
            if (viewContext.ViewBag == null)
                throw new ArgumentNullException("viewContext.ViewBag");
            //Sequential processing is required because the evaluation needs the http context that 
            // parallel implementation does not have on all threads
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
