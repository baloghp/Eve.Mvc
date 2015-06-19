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
            AssetManager.ExtractResource("EVE.Mvc.Samples.Embedded.Views.Mockup.index.cshtml", this.GetType().Assembly, PluginDirectory, "EVE.Mvc.Samples.Embedded/Views");
        }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapRoute("EVE.Mvc.Samples.Embedded",
                "Plugins/TestMockup",
                new { controller = "TestMockup", action = "RetrieveSimpleRazor" },
                new[] { "Bookly.Mvc.TestMockup.Controllers" }
           );
        }
    }
}
