using System;
using System.Collections.Generic;
using System.Configuration.Provider;

namespace EVE.Mvc.Plugin.Providers
{
    public abstract class BaseEmbeddedPluginDefinitionProvider : ProviderBase
    {
        
        public abstract List<Lazy<IEmbeddedPlugin>> GetEmbeddedPluginList();
    }
}