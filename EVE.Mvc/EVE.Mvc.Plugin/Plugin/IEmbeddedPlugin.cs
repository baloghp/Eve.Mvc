using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Optimization;

namespace EVE.Mvc
{
    /// <summary>
    /// Defines initialization functions for the plugin
    /// </summary>
    [InheritedExport]
    public interface IEmbeddedPlugin
    {
        /// <summary>
        /// Embedded File system definitions
        /// </summary>
        IList<EmbeddedFileSystemDefinition> EmbeddedFileSystems { get; }


        /// <summary>
        /// Routes for the plugin to define
        /// </summary>
        IList<RouteDefinition> Routes { get; }

        /// <summary>
        /// Stub to initialize plugin specific bundles
        /// </summary>
        /// <param name="bundles"></param>
        void RegisterBundles(BundleCollection bundles);

    }
    /// <summary>
    /// Class containing the necessary details to define an Embedded File system registration
    /// </summary>
    public class EmbeddedFileSystemDefinition
    {
        /// <summary>
        /// Web app request path that the EFS will serve
        /// </summary>
        public string RequestPath { get; set; }
        /// <summary>
        /// base resource namespace from which the file system is effective
        /// </summary>
        public string BaseResourceNamespace { get; set; }
        /// <summary>
        /// Determines if the files system will be registered with a corresponding virtualPathProvider
        /// </summary>
        public bool RegisterVirtuPathProvider { get; set; }

    }
    /// <summary>
    /// Class containing the necessary details to define Extractable Razor views
    /// </summary>
    public class ExtractRazorViewDefinition
    {
        /// <summary>
        /// Resource name of the RAZOR view
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary>
        /// Base path for the views relative to web application root
        /// </summary>
        public string BasePath { get; set; }
        /// <summary>
        /// path for the view relative to the BasePath
        /// </summary>
        public string ViewPath { get; set; }
    }
    /// <summary>
    /// Class containing the necessary details to define routes for the plugin
    /// </summary>
    public class RouteDefinition
    {
        /// <summary>
        /// Name of the route
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// URL for the route
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Defaults of the route
        /// </summary>
        public object Defaults { get; set; }
        /// <summary>
        /// Namespaces to find the controllers for this route, used by the Mvc ControllerFactory
        /// </summary>
        public string[] Namespaces;
    }

   
}
