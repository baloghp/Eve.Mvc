using EVE.Mvc.Composition;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace EVE.Mvc.Plugin
{
    public static class IAppBuilderExtension
    {
        public static IAppBuilder UseEmbeddedPlugins(this IAppBuilder app, string pluginViewsPath = "")
        {
            var plugins = AppMefContainer.Container.GetExports<IEmbeddedPlugin>();
            foreach (var p in plugins)
            {
                p.Value.InitiaizeEmbeddedFileSystem(app);
                p.Value.RegisterRoutes(RouteTable.Routes);
                
                if (String.IsNullOrWhiteSpace(pluginViewsPath)) 
                    break;
                var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath), "Plugins");
                p.Value.InitializeViews(path);
            }

            return app;
        }
    }
}
