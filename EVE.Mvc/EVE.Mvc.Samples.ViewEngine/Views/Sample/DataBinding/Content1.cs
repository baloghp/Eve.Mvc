using EVE.Mvc.Samples.ViewEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
    [EmbeddedView("eve-Assets.Views.Sample.DataBinding.Content1.html")]
    public class Content1 : DataBindingView<Content>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
           
        }
    }
}
