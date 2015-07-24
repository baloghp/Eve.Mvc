using EVE.Mvc.Samples.ViewEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.DataBinding.Contents.html")]
    public class Contents : DataBindingView<LandingPageModel>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
           
        }
    }
}
