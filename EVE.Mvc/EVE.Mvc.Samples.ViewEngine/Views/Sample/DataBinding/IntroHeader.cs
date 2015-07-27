using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
   [EmbeddedView("eve-Assets.Views.Sample.DataBinding.IntroHeader.html")]
    public class IntroHeader : DataBindingView<Models.IntroHeader>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
