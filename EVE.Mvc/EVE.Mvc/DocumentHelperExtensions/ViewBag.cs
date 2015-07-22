using Dynamitey;
using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc.DocumentHelperExtensions
{
    public static class ViewBag
    {
        public const string ViewBagAttribute = "eve-viewbag";
        
        public static IDocumentHelper ProcessViewBag(this IDocumentHelper documentHelper, ViewContext viewContext)
        {
            var scriptsNodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(ViewBagAttribute));
            foreach (var item in scriptsNodes)
            {

                var value = Dynamic.InvokeGet(viewContext.ViewBag, item.Attributes[ViewBagAttribute].Value);
                EmbeddedView.RenderForNode(item, value.ToString());
            }
          
            return documentHelper;
        }
    }
}
