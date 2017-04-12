using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Web.Routing;
using Microsoft.Owin.Extensions;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Hosting;
using EVE.Mvc.Embedded;
using EVE.Mvc.Plugin.Providers;

namespace EVE.Mvc.Plugin
{
    /// <summary>
    /// static class provising extension methods for IAppBuilder
    /// </summary>
    public static class AppBuilderExtension
    {
        /// <summary>
        ///  automatically discovers all EmbeddedPlugins in your application and configures them based on their IEmbeddedPlugin interfaces
        /// </summary>
        /// <param name="app">IAppBuider to extend</param>
        /// <param name="BeforePluginsInitialized">This action receives the list of plugins discovered by MEF, in the implementation the web application can check for validity of these plugins, if necessary it can remove or add plugin definitions.</param>
        /// <param name="BeforeEmbeddedFileSystemInitialize">This action receives the list of embedded file system definitions which are to be registered, in the implementation the web application can check them, if necessary it can remove or add definitions before processing.</param>
        /// <param name="BeforeRegisteringRoutes">This action receives the list route definitions which are to be registered, in the implementation the web application can check them, if necessary it can remove or add definitions before processing.</param>
        /// <returns></returns>
        public static IAppBuilder UseEmbeddedPlugins(this IAppBuilder app,
            Action<IAppBuilder, IList<Lazy<IEmbeddedPlugin>>> BeforePluginsInitialized = null,
            Action<IAppBuilder, IList<EmbeddedFileSystemDefinition>> BeforeEmbeddedFileSystemInitialize = null,
            Action<IAppBuilder, IList<RouteDefinition>> BeforeRegisteringRoutes = null,
            BaseEmbeddedPluginDefinitionProvider embeddedPliginDefinitionProvider = null)
        {
            if (embeddedPliginDefinitionProvider == null)
            {
                if (EmbeddedPluginDefinitionProvider.CurrentProvider == null)
                    throw new ArgumentNullException("EmbeddedPliginDefinition provider is not specified");
                embeddedPliginDefinitionProvider = EmbeddedPluginDefinitionProvider.CurrentProvider;
            }
            var plugins = embeddedPliginDefinitionProvider.GetEmbeddedPluginList();
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

                p.Value.RegisterBundles(BundleTable.Bundles);

            }

            return app;
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
                var fs = new EmbeddedFileSystem(embeddedPlugin.GetType().Assembly.FullName, item.BaseResourceNamespace);
                var reqPath = new PathString(item.RequestPath);
                app.UseFileServer(new FileServerOptions
           {
               RequestPath = reqPath,
               FileSystem = fs
           });
                if (item.RegisterVirtuPathProvider)
                    HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedPathProvider(fs, reqPath));
                app.UseStageMarker(PipelineStage.MapHandler);
            }
        }


    }
}
