using EVE.Mvc.Composition;
using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine.Providers
{
    public class MEFViewClassProvider : BaseViewClassProvider
    {
        public override IEmbeddedView GetEmbeddedViewClass(string viewName)
        {
            var views = EveMefContainer.Container.GetExports<IEmbeddedView>(viewName);
            if (views != null && views.Count() > 0)
            {
                var view = views.First().Value;
                return view;
            }
            return null;
        }
    }
}
