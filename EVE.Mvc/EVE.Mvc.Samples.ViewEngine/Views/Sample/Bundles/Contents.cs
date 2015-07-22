using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Bundles
{
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Bundles.Contents.html")]
    public class Contents : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            //throw new NotImplementedException();
        }
    }
}
