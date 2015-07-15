using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc.Samples.ViewEngine.Controllers
{
    public class TutorialController : Controller
    {
        public ActionResult RegisterViewEngine()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Tutorial.RegisterViewEngine.html");
        }
        public ActionResult SimpleHtml()
        {
            return View("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Tutorial.SimpleHtml.html");
        }
    }
}
