using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc.TestMockup.Views
{
    [EmbeddedView("Bookly.Mvc.TestMockup.Views.Sample.LandingPage.html")]
    public class LandingPage : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
