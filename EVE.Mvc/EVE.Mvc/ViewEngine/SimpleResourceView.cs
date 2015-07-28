using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// EMbeddedView implementation for the case when no view code is provided.
    /// </summary>
    public class SimpleResourceView: EmbeddedView
    {
      
        public override void ProcessView(ViewContext viewContext)
        {
            //do nothing
        }
    }
}
