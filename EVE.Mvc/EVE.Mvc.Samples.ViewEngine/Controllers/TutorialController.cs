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
            return View("eve-Assets.Views.Tutorial.RegisterViewEngine.html");
        }
        public ActionResult SimpleHtml()
        {
            return View("eve-Assets.Views.Tutorial.SimpleHtml.html");
        }
        public ActionResult SimpleMaster()
        {
            return View("eve-Assets.Views.Tutorial.SimpleMaster.SimpleMaster.html");
        }
        public ActionResult SimpleMasterAndPartial()
        {
            return View("eve-Assets.Views.Tutorial.MasterAndPartials.MasterAndPartials.html");
        }
    }
}
