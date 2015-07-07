using EVE.Mvc.Composition;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Extensions;
using Microsoft.Owin;
using System.Web.Mvc;

namespace EVE.Mvc.Plugin
{
    public static class IAppBuilderExtension
    {
        public static IAppBuilder UseEmbeddedPlugins(this IAppBuilder app,
            string pluginViewsBasePath = "",
            Action<IAppBuilder, IList<Lazy<IEmbeddedPlugin>>> BeforePluginsInitialized = null,
            Action<IAppBuilder, IList<EmbeddedFileSystemDefinition>> BeforeEmbeddedFileSystemInitialize = null,
            Action<IAppBuilder, IList<RouteDefinition>> BeforeRegisteringRoutes = null,
            Action<IAppBuilder, IList<ExtractRazorViewDefinition>> BeforeExtractingRazorViews = null)
        {
            var plugins = EveMefContainer.Container.GetExports<IEmbeddedPlugin>().ToList();
            if (BeforePluginsInitialized != null)
                BeforePluginsInitialized(app, plugins);
            foreach (var p in plugins)
            {
                if (p.Value == null)
                    throw new ApplicationException("Unable to instantiate plugin type: " + p.GetType().AssemblyQualifiedName);
                #region Embedded File system
                if (BeforeEmbeddedFileSystemInitialize != null)
                    BeforeEmbeddedFileSystemInitialize(app, p.Value.EmbeddedFileSystems);

                InitializeEmbeddedFileSystem(app, p.Value);
                #endregion

                #region RoutesRegistry
                if (BeforeRegisteringRoutes != null)
                    BeforeRegisteringRoutes(app, p.Value.Routes);

                RegisterRoutes(app, p.Value);

                #endregion


                #region Razor views
                if (BeforeExtractingRazorViews != null)
                    BeforeExtractingRazorViews(app, p.Value.RazoreViewsToExtract);

                InitializeExtractedViews(app, p.Value, pluginViewsBasePath);
                #endregion

            }

            return app;
        }

        private static void InitializeExtractedViews(IAppBuilder app, IEmbeddedPlugin embeddedPlugin, string pluginViewsBasePath)
        {
            if (embeddedPlugin == null || embeddedPlugin.RazoreViewsToExtract == null) return;
            string basepath = pluginViewsBasePath;
            foreach (var item in embeddedPlugin.RazoreViewsToExtract)
            {
                if (string.IsNullOrWhiteSpace(basepath))
                    basepath = item.BasePath;

                var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath), basepath);
                AssetManager.ExtractResource(item.ResourceName, embeddedPlugin.GetType().Assembly, path, item.ViewPath);
            }
        }

        private static void RegisterRoutes(IAppBuilder app, IEmbeddedPlugin embeddedPlugin)
        {
            if (embeddedPlugin == null || embeddedPlugin.Routes == null) return;

            foreach (var item in embeddedPlugin.Routes)
            {
                RouteTable.Routes.MapRoute(item.RouteName,
                                           item.Url,
                                           item.Defaults,
                                           item.Namespaces);
            }
        }

        private static void InitializeEmbeddedFileSystem(IAppBuilder app, IEmbeddedPlugin embeddedPlugin)
        {
            if (embeddedPlugin == null || embeddedPlugin.EmbeddedFileSystems == null) return;

            foreach (var item in embeddedPlugin.EmbeddedFileSystems)
            {
                app.UseFileServer(new FileServerOptions
           {
               RequestPath = new PathString(item.RequestPath),
               FileSystem = new EmbeddedFileSystem(embeddedPlugin.GetType().Assembly.FullName, item.BaseResourceNamespace)
           });
                app.UseStageMarker(PipelineStage.MapHandler);
            }
        }


    }
}
