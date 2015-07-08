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
    /// <summary>
    /// Static class providing the singleton instance for the MEF container. It is important that for any MEF decision Eve.Mvc uses this catalog.
    /// </summary>
    public static class EveMefContainer
    {
        /// <summary>
        /// Singleton instance of the MEF catalog
        /// </summary>
        public static volatile readonly CompositionContainer Container {get; set;}

        /// <summary>
        /// Static constructor responsible to create the MEF container
        /// </summary>
        static EveMefContainer()
        {
          

            var catalog = CatalogProvider.CurrentProvider.CreateCatalog();
  
            Container = new CompositionContainer(catalog);
        }
    }
}
