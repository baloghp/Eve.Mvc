using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
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

        public static string GetAttributeQuery(string attribute)
        {
            return String.Format("//*[@{0}]", attribute);
        }


        public static string GetAttributeQueryWithRenderInstead(string attribute)
        {
            return String.Format("//*[@{0} and @{1}] ", attribute, EveMarkupAttributes.RenderInstead);
        }
        public static string GetAttributeByValueQuery(string attribute, string value)
        {
            return String.Format("//*[@{0}='{1}']", attribute, value);
        }
        public static string GetAllAttributeValuesQuery(string attribute)
        {
            return String.Format("//*[@{0}]/@{0}", attribute);
        }
     
    }
}
