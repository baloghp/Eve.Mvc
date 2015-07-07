using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Configuration
{
    public class EveProvidersConfigSection : System.Configuration.ConfigurationSection
    {
        private readonly ConfigurationProperty catalogProvider = new ConfigurationProperty("catalogProvider", typeof(ProviderSettings), null);
       
            public EveProvidersConfigSection()
            {
                this.Properties.Add(catalogProvider);
                
            }


            [ConfigurationProperty("catalogProvider")]
            public ProviderSettings CatalogProvider
            {
                get { return (ProviderSettings)base["catalogProvider"]; }
            }



          
        }
    
}
