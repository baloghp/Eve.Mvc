using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public abstract class BaseMarkupProvider: ProviderBase
    {
        public abstract string GetResource(string viewName, EmbeddedView view);
    }
}
