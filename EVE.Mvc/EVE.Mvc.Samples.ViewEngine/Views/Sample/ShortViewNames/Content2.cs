using EVE.Mvc.Samples.ViewEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [EmbeddedView("eve-ShortViewNames.Content2.html", MarkupName = "Assets.Views.Sample.ShortViewNames.Content2.html")]
    public class Content2 : DataBindingView<Content>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {

        }
    }
}
