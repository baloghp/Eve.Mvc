using Microsoft.Owin;
using Owin;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using Bookly.Mvc;
using Microsoft.Owin.Extensions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Bookly.Mvc.TestMockup;
using System.IO;

[assembly: OwinStartupAttribute(typeof(Bookly.Mvc.TestWebApp.Startup))]
namespace Bookly.Mvc.TestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ViewEngines.Engines.Add(new EmbeddedViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          

            ConfigureAuth(app);
            //ConfigureEmbeddedFileSystem(app);

            TestMockupPlugin p = new TestMockupPlugin();
            p.InitiaizeEmbeddedFileSystem(app);
            p.RegisterRoutes(RouteTable.Routes);
            var path =Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath),"Plugins");
            
            p.InitializeViews(path);
            

           
        }

       
    }
}
