using Dynamitey;
using EVE.Mvc.ViewEngine;
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
        public static IDocumentHelper<T> ProcessViewBag<T>(this IDocumentHelper<T> documentHelper, ViewContext viewContext) where T:IDocument
        {
            if (viewContext == null)
                throw new ArgumentNullException("viewContext");
            if (viewContext.ViewBag == null)
                throw new ArgumentNullException("viewContext.ViewBag");
            //Sequential processing is required because the evaluation needs the http context that 
            // parallel implementation does not have on all threads
            documentHelper.ProcessNodesWithAttributeSequential(ViewBagAttribute, new Func<IDocumentNode, string>(a =>
                    {
                        var dynaPath = a.GetAttributeValue(ViewBagAttribute);
                        var value = Dynamic.InvokeGet(viewContext.ViewBag,dynaPath);
                        return value.ToString();
                    }
               ));
            return documentHelper;
        }
    }
}
