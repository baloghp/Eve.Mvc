using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine
{
    public class ViewEngineSamplesPlugin : IEmbeddedPlugin
    {
        public IList<EmbeddedFileSystemDefinition> EmbeddedFileSystems
        {
            get
            {
                // we're reusing the embedded sample's EFS
                return null;
            }
        }

        public IList<ExtractRazorViewDefinition> RazoreViewsToExtract
        {
            get
            {
                // no razor views here
                return null;
            }
        }

        public IList<RouteDefinition> Routes
        {
            get
            {
                return new List<RouteDefinition>
                {
                    new RouteDefinition{
                        RouteName = "EVE.Mvc.Samples.ViewEngine",
                        Url="Plugins/ViewEngineSample/{controller}/{action}",
                        Defaults =  new { controller = "Samples", action = "ShowHtml" },
                        Namespaces = new[] { "EVE.Mvc.Samples.ViewEngine.Controllers" }
                    }
                };
            }
        }
    }
}
