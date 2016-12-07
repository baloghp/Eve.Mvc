using EVE.Mvc.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EVE.Mvc.Providers
{
    public static class DocumentHelperFactory
    {
        /// <summary>
        /// singleton for the catalog provider
        /// </summary>
        public static readonly BaseDocumentHelperFactory Factory;

        /// <summary>
        /// static constructor responsible to create the right instance for the catalog provider
        /// </summary>
        static DocumentHelperFactory()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as EveProvidersConfigSection;
            if (configSection == null || String.IsNullOrWhiteSpace(configSection.CatalogFactory.Type))
            {
                throw new ArgumentException("Missing CatalogProvider");
                //CurrentProvider = new BinDirectoryCatalogProvider();
                //return;
            }
            var provider = ProvidersHelper.InstantiateProvider(configSection.CatalogFactory, typeof(BaseDocumentHelperFactory));
            Factory = (BaseDocumentHelperFactory)provider;

        }
    }
}
