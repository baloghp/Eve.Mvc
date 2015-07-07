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
    public static class CatalogProvider
    {
        public static readonly BaseCatalogProvider CurrentProvider;

        static CatalogProvider()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as EveProvidersConfigSection;
            if (configSection == null) CurrentProvider = new BinDirectoryCatalogProvider();
            var provider = ProvidersHelper.InstantiateProvider(configSection.CatalogProvider, typeof(BaseCatalogProvider));
            CurrentProvider = (BaseCatalogProvider)provider;

        }
    }
}
