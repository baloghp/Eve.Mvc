using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    /// <summary>
    /// Attribute to define MEF export with the view name as contract name, so MEF can easily choose appropriate view class based on view name.
    /// </summary>
    public class EmbeddedViewAttribute : ExportAttribute
    {
        public EmbeddedViewAttribute(string viewName)
            : base(viewName, typeof(IEmbeddedView))
        {

            
        
        }
        
        
    }
}
