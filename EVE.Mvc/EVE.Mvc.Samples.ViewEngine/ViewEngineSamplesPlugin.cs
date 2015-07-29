using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace EVE.Mvc.Samples.ViewEngine
{
    public class ViewEngineSamplesPlugin : IEmbeddedPlugin
    {
        public IList<EmbeddedFileSystemDefinition> EmbeddedFileSystems
        {
            get
            {
                return new List<EmbeddedFileSystemDefinition> 
                                {
                                    new EmbeddedFileSystemDefinition()
                                        {
                                            BaseResourceNamespace="EVE.Mvc.Samples.ViewEngine.Assets",
                                            RequestPath = "/EVE.Mvc.Samples.ViewEngine/Assets",
                                            
                                        }
                                };
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


        public void RegisterBundles(System.Web.Optimization.BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lp/bootstrap").Include(
                      "~/EVE.Mvc.Samples.Embedded/Assets/LandingPage/js/jquery.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/lp/css").Include(
                      "~/EVE.Mvc.Samples.Embedded/Assets/LandingPage/css/bootstrap.css",
                      "~/EVE.Mvc.Samples.Embedded/Assets/LandingPage/css/landing-page.css",
                      "~/EVE.Mvc.Samples.Embedded/Assets/LandingPage/font_awesome/css/font-awesome.css"));
        }
    }
}
