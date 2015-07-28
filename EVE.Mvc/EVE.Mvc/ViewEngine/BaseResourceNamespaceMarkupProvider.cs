using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Markup provider using a base resource namespace, that it attaches to the view name before looking for it as an embedded resource.
    /// Use this when you register an embedded view engine for each embedded plugin, then you can shorten the view names, with the assembly's name.
    /// </summary>
    public class BaseResourceNamespaceMarkupProvider : BaseMarkupProvider
    {
        public readonly string BaseResourceNamespace;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResourceNamespaceMarkupProvider"/> class.
        /// </summary>
        /// <param name="baseResourceNamespace">The base resource namespace.</param>
        public BaseResourceNamespaceMarkupProvider( string baseResourceNamespace)
        {
            this.BaseResourceNamespace = baseResourceNamespace;
        }
        /// <summary>
        /// Gets the markup based on the view name and the view class. The view name is prefixed with the base namespace before it is looked up as an embedded resource.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="view">The view class, can be null.</param>
        /// <returns></returns>
/        public override string GetResource(string viewName, IEmbeddedView view)
        {
            string markup = String.Empty;
            string newViewName = BaseResourceNamespace + "." + viewName;
            if (view != null)
            {
                
                markup = AssetManager.LoadResourceString(newViewName, view.GetType().Assembly);
            }
            if (string.IsNullOrWhiteSpace(markup))
            {
                markup = AssetManager.LoadResourceString(newViewName);
            };
            return markup;
        }
    }
}
