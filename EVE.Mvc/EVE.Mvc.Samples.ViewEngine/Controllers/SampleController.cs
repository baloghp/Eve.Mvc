using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.MasterAndPartials.LandingPage.html",DateTime.Now);
        }

    }
}
