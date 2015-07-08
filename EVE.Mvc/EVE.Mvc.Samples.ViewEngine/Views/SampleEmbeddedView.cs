using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.TestMockup.Views
{
    [EmbeddedView("Bookly.Mvc.TestMockup.Views.Mockup.index.cshtml")]
    public class SampleEmbeddedView : EmbeddedView
    {
        

        public override void ProcessView( System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
