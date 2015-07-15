using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public class EmbeddedMarkupProvider: BaseMarkupProvider
    {
        public override string GetResource(string viewName, EmbeddedView view)
        {
            string markup = String.Empty;
            if (view != null)
            {
                markup = AssetManager.LoadResourceString(viewName, view.GetType().Assembly);
            }
            if (string.IsNullOrWhiteSpace(markup))
            {
                markup = AssetManager.LoadResourceString(viewName);
            };
            return markup;
        }
    }
}
