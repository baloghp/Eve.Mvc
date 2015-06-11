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

namespace Bookly.Mvc.TestMockup
{
    public class TestMockupPlugin : IEmbeddedPlugin
    {


        public void InitiaizeEmbeddedFileSystem(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString("/Bookly.Mvc.TestMockup/Assets"),
                FileSystem = new EmbeddedFileSystem("Bookly.Mvc.TestMockup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Bookly.Mvc.TestMockup.Assets")
            });
            app.UseStageMarker(PipelineStage.MapHandler);
        }

        public void InitializeViews(string PluginDirectory)
        {
            AssetManager.ExtractResource("Bookly.Mvc.TestMockup.Views.Mockup.index.cshtml", this.GetType().Assembly, PluginDirectory, "Bookly.Mvc.TestMockup/Views");
        }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapRoute("Bookly.Mvc.TestMockup",
                "Plugins/TestMockup",
                new { controller = "TestMockup", action = "RetrieveSimpleRazor" },
                new[] { "Bookly.Mvc.TestMockup.Controllers" }
           );
        }
    }
}
