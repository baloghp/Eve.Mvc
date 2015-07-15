using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Configuration
{
    /// <summary>
    /// Config section to configure providers used by Eve.Mvc
    /// </summary>
    public class EveProvidersConfigSection : System.Configuration.ConfigurationSection
    {
        private readonly ConfigurationProperty catalogProvider = new ConfigurationProperty("catalogProvider", typeof(ProviderSettings), null);
       
            public EveProvidersConfigSection()
            {
                this.Properties.Add(catalogProvider);
                
            }

        /// <summary>
        /// Provider for creating the MEF Catalog that EveMefContainer.Container is based on.
        /// </summary>
            [ConfigurationProperty("catalogProvider")]
            public ProviderSettings CatalogProvider
            {
                get { return (ProviderSettings)base["catalogProvider"]; }
            }




            /// <summary>
            /// Provider for getting markup for the Embedded View Engine.
            /// </summary>
            [ConfigurationProperty("markupProvider")]
            public ProviderSettings MarkupProvider
            {
                get { return (ProviderSettings)base["markupProvider"]; }
            }
    }
    
}
