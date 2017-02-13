using EVE.Mvc.Composition;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVE.Mvc.Plugin.Providers
{
    public class MEFEmbeddedPluginDefinitionsProvider : BaseEmbeddedPluginDefinitionProvider
    {
        public override List<Lazy<IEmbeddedPlugin>> GetEmbeddedPluginList()
        {
           return EveMefContainer.Container.GetExports<IEmbeddedPlugin>().ToList();
        }
    }
}
