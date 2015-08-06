using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [EmbeddedView("eve-Assets.Views.Sample.ShortViewNames.LandingMaster.html" , MarkupName = "Assets.Views.Sample.ShortViewNames.LandingMaster.html")]
    public class MasterView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
