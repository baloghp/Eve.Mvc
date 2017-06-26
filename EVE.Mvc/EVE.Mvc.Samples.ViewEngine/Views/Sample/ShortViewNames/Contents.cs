using EVE.Mvc.Samples.ViewEngine.Models;
using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [EmbeddedView("eve-ShortViewNames.Contents.html")]
    [MarkupName("Assets.Views.Sample.ShortViewNames.Contents.html")]
    public class Contents : DataBindingView<LandingPageModel>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
           
        }
    }
}
