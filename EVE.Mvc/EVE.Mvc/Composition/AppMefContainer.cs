using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Hosting;

namespace EVE.Mvc.Composition
{
    public static class AppMefContainer
    {

        public static CompositionContainer Container {get; set;}

        static AppMefContainer()
        {
            if (AppDomain.CurrentDomain == null)
                throw new ApplicationException("AppDomain does not exist. AppDomain is needed in order to create MEF container.");
            
            DirectoryCatalog dcat = new DirectoryCatalog(Path.Combine(HostingEnvironment.ApplicationPhysicalPath,"bin"));
           
            //var asmCatalogs = from a in BuildManager.GetReferencedAssemblies().Cast<Assembly>()
            //                  select (new AssemblyCatalog(a));
            
           
            //AggregateCatalog aggregateCatalog = new AggregateCatalog(asmCatalogs);
            Container = new CompositionContainer(dcat);
        }
    }
}
