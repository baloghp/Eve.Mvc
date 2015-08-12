using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.DataBinding
{
    public abstract class DataBindingView<T> : EmbeddedView<T>
    {
        protected override void BeforeProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            base.BeforeProcessView(viewContext);
            this.HtmlDocument
                .ProcessEvals(this.Model);
        }
    }
}
