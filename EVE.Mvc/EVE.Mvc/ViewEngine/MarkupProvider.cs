using EVE.Mvc.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Singleton implementation for default markup provider.
    /// </summary>
    public static class MarkupProvider
    {
         /// <summary>
        /// singleton for the markup provider
        /// </summary>
        public static readonly BaseMarkupProvider CurrentProvider;

        /// <summary>
        /// static constructor responsible to create the right instance for the markup provider
        /// </summary>
        static MarkupProvider()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as EveProvidersConfigSection;
            if (configSection == null || String.IsNullOrWhiteSpace(configSection.MarkupProvider.Type))
            {
                CurrentProvider = new EmbeddedMarkupProvider();
                return;
            }
            var provider = ProvidersHelper.InstantiateProvider(configSection.MarkupProvider, typeof(BaseMarkupProvider));
            CurrentProvider = (BaseMarkupProvider)provider;

        }
    }
}
