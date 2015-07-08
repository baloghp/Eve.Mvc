using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc;

namespace EVE.Mvc.TestMockup.Views
{
     [EmbeddedView("Bookly.Mvc.TestMockup.Views.Sample.EntireLandingPage.html")]
    public class EntireLandingPageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument.ProcessViewBag(viewContext);
        }
    }
}
