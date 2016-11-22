using Microsoft.Owin;
using Owin;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using EVE.Mvc;
using Microsoft.Owin.Extensions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.IO;
using EVE.Mvc.Plugin;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.ViewEngine.Providers;

[assembly: OwinStartupAttribute(typeof(EVE.Mvc.TestWebApp.Startup))]
namespace EVE.Mvc.TestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //registry for the view engine samples, more specific goes first
            ViewEngines.Engines.Insert(0, 
                new EmbeddedViewEngine("eve-" // every view name will be prefixed by this
                    , new BaseResourceNamespaceMarkupProvider("EVE.Mvc.Samples.ViewEngine") // using this markup provider, so we can have somewhat shorter view names
                    )); 
            
            //registry for any generic case 
            // this project won't use this, Embedded FIle system samples, do not use the view engine, 
            // EVE views are only in the view engine samples project, that is caught by the VE above
            // so this registry goes as last
            ViewEngines.Engines.Add(new EmbeddedViewEngine()); // NO view prefix, default markup provider
           
            #region standard startup

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          

            ConfigureAuth(app);
            #endregion

            app.UseEmbeddedPlugins();
            

           
        }



        
    }
}
