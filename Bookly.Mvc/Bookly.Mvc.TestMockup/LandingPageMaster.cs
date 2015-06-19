using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.TestMockup
{
    [EmbeddedView("Bookly.Mvc.TestMockup.Views.Sample.LandingPageMaster.html")]
    public class LandingPageMaster: EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
