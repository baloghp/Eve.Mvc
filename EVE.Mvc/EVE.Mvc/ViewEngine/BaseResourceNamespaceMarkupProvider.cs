using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public class BaseResourceNamespaceMarkupProvider : BaseMarkupProvider
    {
        public readonly string BaseResourceNamespace;
        public BaseResourceNamespaceMarkupProvider( string baseResourceNamespace)
        {
            this.BaseResourceNamespace = baseResourceNamespace;
        }
       
        public override string GetResource(string viewName, IEmbeddedView view)
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
