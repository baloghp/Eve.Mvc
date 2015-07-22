using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Sections
{
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Sections.LandingMaster.html")]
    public class MasterView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
