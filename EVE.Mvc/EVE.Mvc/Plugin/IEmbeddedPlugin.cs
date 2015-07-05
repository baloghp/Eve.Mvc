using Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;


namespace EVE.Mvc
{
    /// <summary>
    /// Defines initialization functions for the plugin
    /// </summary>
    [InheritedExport]
    public interface IEmbeddedPlugin
    {

        IEnumerable<EmbeddedFileSystemDefinition> EmbeddedFileSystems { get; }

        IEnumerable<ExtractRazorViewDefinition> RazoreViewsToExtract { get; }

        IEnumerable<RouteDefinition> Routes { get; }

    }

    public class EmbeddedFileSystemDefinition
    {
        public string RequestPath { get; set; }
        public string BaseResourceNamespace { get; set; }

    }

    public class ExtractRazorViewDefinition
    {
        public string ResourceName { get; set; }
        public string BasePath { get; set; }
        public string ViewPath { get; set; }
    }

    public class RouteDefinition
    {
        public string RouteName { get; set; }
        public string Url { get; set; }
        public object Defaults { get; set; }
        public string[] Namespaces;
    }
}
