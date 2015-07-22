using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.DocumentHelperExtensions;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Sections
{
    [MasterView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Sections.LandingMaster.html")]
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Sections.LandingPage.html")]
    public class PageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            

        }
    }
}
