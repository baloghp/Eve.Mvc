using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;


namespace EVE.Mvc
{
    /// <summary>
    /// Extension methods for localization
    /// </summary>
    public static class Localization
    {
        public const string LocalAttribute = "eve-local";
        /// <summary>
        /// Processes the html document's tags with LocalAttribute ("eve-local") attributes, 
        /// by evaluating the given attribute value on the specified ResourceManager with the specified culture, and inserting the result into the tag.
        /// </summary>
        /// <param name="documentHelper">Document this extension is attached on</param>
        /// <param name="resourceManager">ResourceManager referring to the resx file for resources</param>
        /// <param name="culture">Required culture for the localization</param>
        /// <returns></returns>
        public static IDocumentHelper<T> ProcessLocals<T>(this IDocumentHelper<T> documentHelper, ResourceManager resourceManager, CultureInfo culture) where T: IDocument
        {
            if (resourceManager == null)
                throw new ArgumentNullException("resourceManager");
            if (culture == null)
                throw new ArgumentNullException("culture");

            documentHelper.ProcessNodesWithAttribute(LocalAttribute, new Func<IDocumentNode, string>(a =>
            {
                var resourceKey = a.GetAttributeValue(LocalAttribute);
                return resourceManager.GetString(resourceKey,culture);
            }
               ));
            return documentHelper;
        }
    }
}
