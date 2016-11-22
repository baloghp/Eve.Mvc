using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine.Providers
{
    public abstract class BaseViewClassProvider : ProviderBase
    {
        public abstract IEmbeddedView GetEmbeddedViewClass(string viewName);
    }
}
