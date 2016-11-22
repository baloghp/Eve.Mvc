using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine.Providers
{
    /// <summary>
    /// Base Markup provider abstraction
    /// </summary>
    public abstract class BaseMarkupProvider: ProviderBase
    {
        /// <summary>
        /// Gets the markup based on the viewname and the view class.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="view">The view class, can be null.</param>
        /// <returns></returns>
        public abstract string GetResource(string viewName, IEmbeddedView view);
    }
}
