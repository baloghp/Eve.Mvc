using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Bookly.Mvc.TestMockup.Controllers
{
   public class TestMockupController : Controller
    {
        public ActionResult RetrieveHtml()
        {
            return View("Bookly.Mvc.TestMockup.Assets.LandingPage.index2.html");
        }

        public ActionResult RetrieveSimpleRazor()
        {
            return View("/Plugins//Bookly.Mvc.TestMockup/Views/index.cshtml");
         
        }
        public ActionResult RetrieveSimpleEmbedded()
        {
            return View("Bookly.Mvc.TestMockup.Views.Mockup.index.cshtml");
        }
    }
}
