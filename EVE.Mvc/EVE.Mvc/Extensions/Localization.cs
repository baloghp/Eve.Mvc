using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    public static class Localization
    {
        public const string LocalAttribute = "eve-local";
        public static IDocumentHelper ProcessLocals(this IDocumentHelper documentHelper, ResourceManager resourceManager, CultureInfo culture)
        {
            documentHelper.ProcessNodesWithAttribute(LocalAttribute, new Func<HtmlNode, string>(a =>
            {
                var resourceKey = a.Attributes[LocalAttribute].Value;
                return resourceManager.GetString(resourceKey,culture);
            }
               ));
            return documentHelper;
        }
    }
}
