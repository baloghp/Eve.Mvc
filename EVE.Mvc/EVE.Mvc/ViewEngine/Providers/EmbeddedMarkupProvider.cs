using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine.Providers
{
    /// <summary>
    /// Markup provider that returns the views if the view name refers to a valid embedded html, or snippet of html.
    /// </summary>
    public class EmbeddedMarkupProvider: BaseMarkupProvider
    {
        public override string GetResource(string viewName, IEmbeddedView view)
        {
            string markup = String.Empty;
            // first let's try if the code and the resource are in the same assembly, 
            //otherwise we have to figure out which assembly the view belongs to
            if (view != null)
            {
                markup = AssetManager.LoadResourceString(viewName, view.GetType().Assembly);
            }
            //if we could not find it there or there is no class specified let's try by searching everywhere
            if (string.IsNullOrWhiteSpace(markup))
            {
                markup = AssetManager.LoadResourceString(viewName);
            };
            return markup;
        }
    }
}
