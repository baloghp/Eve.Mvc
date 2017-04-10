using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public class MarkupNameAttribute : Attribute
    {
        public string MarkupName { get; set; }
        public MarkupNameAttribute(string markupName)
        {
            MarkupName = markupName;
        }
    }
}
