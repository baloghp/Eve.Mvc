using Dynamitey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{
    public static class DocumentHelperExtensions
    {
        public static IDocumentHelper ProcessViewBag(this IDocumentHelper documentHelper, ViewContext viewContext)
        {
            var contents = documentHelper.Document.DocumentNode.SelectNodes("//*[@ev-viewbag]");
            foreach (var item in contents)
            {
                var value = Dynamic.InvokeGet(viewContext.ViewBag, item.Attributes["ev-viewbag"].Value);
                item.InnerHtml = value.ToString();
            }
            return documentHelper;
        }
    }
}
