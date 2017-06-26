using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.ShortViewNames
{
    public abstract class PreprocessingPageView<T> : DataBindingView<T>
    {
        protected override void BeforeProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            base.BeforeProcessView(viewContext);
            this.HtmlDocument
                .ProcessBundles()
                .ProcessViewBag(viewContext);
                
        }
        
    }
}
