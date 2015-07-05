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

namespace EVE.Mvc.TestMockup
{
    public class TestMockupPlugin : IEmbeddedPlugin
    {
        public void InitiaizeEmbeddedFileSystem(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString("/EVE.Mvc.Samples.Embedded/Assets"),
                FileSystem = new EmbeddedFileSystem("EVE.Mvc.Samples.Embedded, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "EVE.Mvc.Samples.Embedded.Assets")
            });
            app.UseStageMarker(PipelineStage.MapHandler);
        }

        public void InitializeViews(string PluginDirectory)
        {
            var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath), "Plugins");
            AssetManager.ExtractResource("EVE.Mvc.Samples.Embedded.Views.Sample.index.cshtml", this.GetType().Assembly, path, "EVE.Mvc.Samples.Embedded/Views");
        }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapRoute("EVE.Mvc.Samples.Embedded",
                "Plugins/EmbeddedSample/{controller}/{action}",
                new { controller = "Samples", action = "RetrieveHtmlResult" },
                new[] { " EVE.Mvc.Samples.Embedded.Controllers" }
           );
        }

        public IEnumerable<EmbeddedFileSystemDefinition> EmbeddedFileSystems
        {
            get
            {
                return new List<EmbeddedFileSystemDefinition> 
                                {
                                    new EmbeddedFileSystemDefinition()
                                        {
                                            BaseResourceNamespace="EVE.Mvc.Samples.Embedded.Assets",
                                            RequestPath = "/EVE.Mvc.Samples.Embedded/Assets",
                                            
                                        }
                                };
            }
        }

        public IEnumerable<ExtractRazorViewDefinition> RazoreViewsToExtract
        {
            get { return new List<ExtractRazorViewDefinition>{
                new ExtractRazorViewDefinition
                {
                    BasePath = "Plugins",
                    ResourceName = "EVE.Mvc.Samples.Embedded.Views.Sample.index.cshtml",
                    ViewPath = "EVE.Mvc.Samples.Embedded/Views"
                }
            
            };
            }
        }

        public IEnumerable<RouteDefinition> Routes
        {
            get
            {
                return new List<RouteDefinition>
                {
                    new RouteDefinition{
                        RouteName = "EVE.Mvc.Samples.Embedded",
                        Url="Plugins/EmbeddedSample/{controller}/{action}",
                        Defaults =  new { controller = "Samples", action = "RetrieveHtmlResult" },
                        Namespaces = new[] { " EVE.Mvc.Samples.Embedded.Controllers" }
                    }
                };
            }
        }
    }
}
