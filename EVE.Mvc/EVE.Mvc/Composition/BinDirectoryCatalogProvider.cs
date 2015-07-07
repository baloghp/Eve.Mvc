using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace EVE.Mvc.Composition
{
    public class BinDirectoryCatalogProvider : BaseCatalogProvider
    {
        public override System.ComponentModel.Composition.Primitives.ComposablePartCatalog CreateCatalog()
        {
            return new DirectoryCatalog(Path.Combine(HostingEnvironment.ApplicationPhysicalPath,"bin"));
        }
    }
}
