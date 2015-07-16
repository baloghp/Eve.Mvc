using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.SimpleMaster
{
    [MasterView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.SimpleMaster.LandingMaster.html")]
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.SimpleMaster.LandingPage.html")]
    public class PageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            //throw new NotImplementedException();
        }
    }
}
