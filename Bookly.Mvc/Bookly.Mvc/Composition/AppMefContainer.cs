using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Composition
{
    public static class AppMefContainer
    {

        public static CompositionContainer Container {get; private set;}

        static AppMefContainer()
        {
            if (AppDomain.CurrentDomain == null)
                throw new ApplicationException("AppDomain does not exist. AppDomain is needed in order to create MEF container.");

            var asmCatalogs = from a in AppDomain.CurrentDomain.GetAssemblies()
                              select (new AssemblyCatalog(a));
            AggregateCatalog aggregateCatalog = new AggregateCatalog(asmCatalogs);
            Container = new CompositionContainer(aggregateCatalog);
        }
    }
}
