using EVE.Mvc.Samples.ViewEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
    [EmbeddedView("eve-Assets.Views.Sample.DataBinding.Content3.html")]
    public class Content3 : DataBindingView<Content>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {

        }
    }
}
