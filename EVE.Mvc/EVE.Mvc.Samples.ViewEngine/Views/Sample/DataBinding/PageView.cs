using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.Samples.ViewEngine.Models;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
    [MasterView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.DataBinding.LandingMaster.html")]
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.DataBinding.LandingPage.html")]
    public class PageView : PreprocessingPageView<LandingPageModel>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
