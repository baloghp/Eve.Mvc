using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Composition
{
    public abstract class BaseCatalogProvider : ProviderBase
    {
        public abstract ComposablePartCatalog CreateCatalog();
    }
}
