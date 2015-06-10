using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc
{
    public class EmbeddedViewAttribute : ExportAttribute
    {
        
        public EmbeddedViewAttribute(string contractName) : base(contractName,typeof(EmbeddedView))
        {}
        
        
    }
}
