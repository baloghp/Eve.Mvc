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
    /// <summary>
    /// Catalog provider implementation that takes uses a DirectoryCatalog on the web application's bin directory
    /// </summary>
    public class BinDirectoryCatalogProvider : BaseCatalogProvider
    {
        /// <summary>
        /// Creates a DirectoryCatalog on the web application's bin directory 
        /// </summary>
        /// <returns>DirectoryCatalog on the web application's bin directory</returns>
        public override System.ComponentModel.Composition.Primitives.ComposablePartCatalog CreateCatalog()
        {
            return new DirectoryCatalog(Path.Combine(HostingEnvironment.ApplicationPhysicalPath,"bin"));
        }
    }
}
