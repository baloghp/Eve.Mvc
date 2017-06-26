using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.Samples.ViewEngine.Models;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [MasterView("eve-Assets.Views.Sample.ShortViewNames.LandingMaster.html")]
    [EmbeddedView("eve-ShortViewNames.LandingPage.html")]
    [MarkupName( "Assets.Views.Sample.ShortViewNames.LandingPage.html")]
    public class PageView : PreprocessingPageView<LandingPageModel>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
