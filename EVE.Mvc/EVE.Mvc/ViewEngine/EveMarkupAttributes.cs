using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Collecition of attributes and utility methods that one can use in markup. See documentation for more detail
    /// </summary>
    public static class EveMarkupAttributes
    {
        //renders
        public const string RenderBody = "eve-renderbody";
        public const string RenderInstead = "eve-renderinstead";
        public const string RenderInto = "eve-renderinto";
        public const string RenderOnlyContent = "eve-renderonlycontent";
        //partial
        public const string PartialView = "eve-partial";
        public const string PartialModel = "eve-partialmodel";
        //section
        public const string SectionDefinition = "eve-section";
        public const string SectionContentFor = "eve-sectioncontentfor";
        //

        /// <summary>
        /// Gets the XPATH query that returns all nodes with given attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        public static string GetAttributeQuery(string attribute)
        {
            return String.Format("//*[@{0}]", attribute);
        }


        /// <summary>
        /// Gets the XPATH query that returns all nodes with given attribute and the renderinstead attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        public static string GetAttributeQueryWithRenderInstead(string attribute)
        {
            return String.Format("//*[@{0} and @{1}] ", attribute, EveMarkupAttributes.RenderInstead);
        }

        /// <summary>
        /// Gets the XPATH query that returns all nodes with given attribute with the specified value.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetAttributeByValueQuery(string attribute, string value)
        {
            return String.Format("//*[@{0}='{1}']", attribute, value);
        }

        
     
    }
}
