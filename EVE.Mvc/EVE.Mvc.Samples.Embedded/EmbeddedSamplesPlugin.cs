using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Extensions;
using Microsoft.Owin;
using System.Web.Mvc;
using System.IO;
using EVE.Mvc;

namespace EVE.Mvc.TestMockup
{
    public class EmbeddedSamplesPlugin : IEmbeddedPlugin
    {
      public IList<EmbeddedFileSystemDefinition> EmbeddedFileSystems
        {
            get
            {
                return new List<EmbeddedFileSystemDefinition> 
                                {
                                    new EmbeddedFileSystemDefinition()
                                        {
                                            BaseResourceNamespace="EVE.Mvc.Samples.Embedded.Assets",
                                            RequestPath = "/EVE.Mvc.Samples.Embedded/Assets",
                                            RegisterVirtuPathProvider = true
                                            
                                        },
                                        new EmbeddedFileSystemDefinition()
                                        {
                                            BaseResourceNamespace="EVE.Mvc.Samples.Embedded.Views",
                                            RequestPath = "/EVE.Mvc.Samples.Embedded/Views",
                                            RegisterVirtuPathProvider = true
                                        }
                                };
            }
        }

    

      public IList<RouteDefinition> Routes
        {
            get
            {
                return new List<RouteDefinition>
                {
                    new RouteDefinition{
                        RouteName = "EVE.Mvc.Samples.Embedded",
                        Url="Plugins/EmbeddedSample/{controller}/{action}",
                        Defaults =  new { controller = "Samples", action = "RetrieveHtmlResult" },
                        Namespaces = new[] { "EVE.Mvc.Samples.Embedded.Controllers" }
                    }
                };
            }
        }


      public void RegisterBundles(System.Web.Optimization.BundleCollection bundles)
      {
         
      }
    }
}
