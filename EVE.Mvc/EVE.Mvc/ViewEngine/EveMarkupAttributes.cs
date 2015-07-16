using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public static class EveMarkupAttributes
    {
        public const string RenderBody = "eve-renderbody";
        public const string RenderInstead = "eve-renderinstead";
        public const string PartialView = "eve-partial";
        public const string PartialModel = "eve-partialmodel";
       

        public static string GetAttributeQuery(string attribute)
        {
            return String.Format("//*[@{0}]", attribute);
        }
    }
}
