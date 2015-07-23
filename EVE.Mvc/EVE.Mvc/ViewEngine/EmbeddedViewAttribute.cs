using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    public class EmbeddedViewAttribute : ExportAttribute
    {

        public EmbeddedViewAttribute(string viewName)
            : base(viewName, typeof(IEmbeddedView))
        {}
        
        
    }
}
