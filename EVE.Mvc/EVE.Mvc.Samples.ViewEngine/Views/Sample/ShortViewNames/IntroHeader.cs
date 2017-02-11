using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
   [EmbeddedView("eve-ShortViewNames.IntroHeader.html")]
    [MarkupName( "Assets.Views.Sample.ShortViewNames.IntroHeader.html")]
    public class IntroHeader : DataBindingView<Models.IntroHeader>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
