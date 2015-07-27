using EVE.Mvc.Samples.ViewEngine.L10N;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc.Samples.ViewEngine.Controllers
{
    public class SampleController : Controller
    {
        public ActionResult ShowResourceHtml() 
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.SimpleHtml.LandingPage.html");
        }

        public ActionResult ShowCodeHtml()
        {
            return View("eve-Just.Code.Simple.Html.View");
        }

        public ActionResult ShowSimpleMasterHtml()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.SimpleMaster.LandingPage.html");
        }

        public ActionResult ShowSimpleMasterAndPartial()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.MasterAndPartials.LandingPage.html");
        }

        public ActionResult Sections()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Sections.LandingPage.html");
        }
        public ActionResult Bundles()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Bundles.LandingPage.html");
        }
        public ActionResult Typed()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Typed.LandingPage.html", Models.LandingPageModel.GetSample());
        }
        public ActionResult DataBinding()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.DataBinding.LandingPage.html", Models.LandingPageModel.GetSample());
        }

        public ActionResult BundlesInJapan()
        {
         
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Bundles.LandingPage.html");
        }
    }
}
