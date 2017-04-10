using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EVE.Mvc.Plugin.Providers
{
    public static class EmbeddedPluginDefinitionProvider
    {

        /// <summary>
        /// singleton for the markup provider
        /// </summary>
        public static readonly BaseEmbeddedPluginDefinitionProvider CurrentProvider;

        /// <summary>
        /// static constructor responsible to create the right instance for the markup provider
        /// </summary>
        static EmbeddedPluginDefinitionProvider()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as Configuration.EveProvidersConfigSection;
            if (configSection == null || String.IsNullOrWhiteSpace(configSection.MarkupProvider.Type))
            {
                throw new ArgumentException("Missing EmbeddedPluginDefinitionProvider");
                //CurrentProvider = new MEFEmbeddedPluginDefinitionsProvider();
                //return;
            }
            var provider = ProvidersHelper.InstantiateProvider(configSection.PluginDefinitionsProvider, typeof(BaseEmbeddedPluginDefinitionProvider));
            CurrentProvider = (BaseEmbeddedPluginDefinitionProvider)provider;

        }
    }

}
