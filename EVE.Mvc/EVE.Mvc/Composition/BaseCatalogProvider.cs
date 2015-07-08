using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Composition
{
    /// <summary>
    /// Base class for Catalog provider
    /// </summary>
    public abstract class BaseCatalogProvider : ProviderBase
    {
        /// <summary>
        /// Method definition to be overriden in child implementaitons that creates the MEF catalog
        /// </summary>
        /// <returns>Eve MEF catalog</returns>
        public abstract ComposablePartCatalog CreateCatalog();
    }
}
