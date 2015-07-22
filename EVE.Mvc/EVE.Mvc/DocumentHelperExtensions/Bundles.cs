using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc.DocumentHelperExtensions
{
    public static class Bundles
    {
        public const string Scripts = "eve-scripts";
        public const string Styles = "eve-styles";
        public static IDocumentHelper ProcessBundles(this IDocumentHelper documentHelper)
        {

            var stylesNodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(Styles));
            foreach (var item in stylesNodes)
            {
                var scriptName = item.Attributes[Styles].Value;
                var value = System.Web.Optimization.Styles.Render(scriptName);
                EmbeddedView.RenderForNode(item, value.ToHtmlString());
            }

            var scriptsNodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(Scripts));
            foreach (var item in scriptsNodes)
            {
                var scriptName = item.Attributes[Scripts].Value;
                var value = System.Web.Optimization.Scripts.Render(scriptName);
                EmbeddedView.RenderForNode(item, value.ToHtmlString());
            }
         
            return documentHelper;
        }
    }
}
