using EVE.Mvc.Samples.ViewEngine.Models;
using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    [EmbeddedView("eve-ShortViewNames.Content1.html")]
    [MarkupName("Assets.Views.Sample.ShortViewNames.Content1.html")]
    public class Content1 : DataBindingView<Content>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
           
        }
    }
}
