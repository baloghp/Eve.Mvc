using EVE.Mvc.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EVE.Mvc.Composition
{
    /// <summary>
    /// Static class containing responsible to instantiate the correct Catalog Provider based on configuration
    /// </summary>
    public static class CatalogFactory
    {
        /// <summary>
        /// singleton for the catalog provider
        /// </summary>
        public static readonly BaseCatalogFactory Factory;

        /// <summary>
        /// static constructor responsible to create the right instance for the catalog provider
        /// </summary>
        static CatalogFactory()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as EveProvidersConfigSection;
            if (configSection == null || String.IsNullOrWhiteSpace(configSection.CatalogFactory.Type))
            {
                throw new ArgumentException("Missing CatalogProvider");
                //CurrentProvider = new BinDirectoryCatalogProvider();
                //return;
            }
            var provider = ProvidersHelper.InstantiateProvider(configSection.CatalogFactory, typeof(BaseCatalogFactory));
            Factory = (BaseCatalogFactory)provider;

        }
    }
}
