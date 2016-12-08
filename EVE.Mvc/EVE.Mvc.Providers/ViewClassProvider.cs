using EVE.Mvc.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace EVE.Mvc.ViewEngine.Providers
{
    public static class ViewClassProvider
    {

        /// <summary>
        /// singleton for the markup provider
        /// </summary>
        public static readonly BaseViewClassProvider CurrentProvider;

        /// <summary>
        /// static constructor responsible to create the right instance for the markup provider
        /// </summary>
        static ViewClassProvider()
        {
            var configSection = ConfigurationManager.GetSection("EveProviders") as EveProvidersConfigSection;
            if (configSection == null || String.IsNullOrWhiteSpace(configSection.ViewProvider.Type))
            {
                throw new ArgumentException("Missing ViewClassProvider");
                //CurrentProvider = new MEFViewClassProvider();
                //return;
            }
            var provider = ProvidersHelper.InstantiateProvider(configSection.ViewProvider, typeof(BaseViewClassProvider));
            CurrentProvider = (BaseViewClassProvider)provider;

        }
    }
}
