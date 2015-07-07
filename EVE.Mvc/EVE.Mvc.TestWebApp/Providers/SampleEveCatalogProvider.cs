using EVE.Mvc.Composition;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace EVE.Mvc.TestWebApp.Providers
{
    public class SampleEveCatalogProvider : BaseCatalogProvider
    {
        public override ComposablePartCatalog CreateCatalog()
        {
            var binPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath,"bin");
            AssemblyCatalog a1 = new AssemblyCatalog(Path.Combine(binPath, "EVE.Mvc.Samples.Embedded.dll"));
            AssemblyCatalog a2 = new AssemblyCatalog(Path.Combine(binPath, "EVE.Mvc.Samples.ViewEngine.dll"));
            AggregateCatalog aggregate = new AggregateCatalog(a1, a2);
            return aggregate;
        }
    }
}