using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [EmbeddedView("eve-ShortViewNames.Banner.html")]
    [MarkupName("Assets.Views.Sample.ShortViewNames.Banner.html")]
    public class Banner : DataBindingView<Models.Banner>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
        
        }
    }
}
