using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EVE.Mvc.TestMockup.Controllers
{
    public class SamplesController : Controller
    {

        public ActionResult RetrieveHtmlResult()
        {
            return new EmbeddedHtmlStringResult("EVE.Mvc.Samples.Embedded.Assets.LandingPage.index2.html", this.GetType().Assembly);
        }

        public ActionResult RetrieveSimpleRazor()
        {
            return View("/Plugins/EVE.Mvc.Samples.Embedded/Views/index.cshtml");

        }
    }
      

     
       // public ActionResult RetrieveSimpleEmbedded()
       // {
       //     return View("EVE.Mvc.Samples.Embedded.Views.Mockup.index.cshtml");
       // }

       // public ActionResult SampleEntireLandingPage()
       // {
       //     ViewBag.Title = "Viewbag title from controller";
       //     ViewBag.Header = "Viewbag header from controller";

       //     return View("EVE.Mvc.Samples.Embedded.Views.Sample.EntireLandingPage.html");
       // }

       // public ActionResult SampleLandingPageWithMaster()
       // {
       //     ViewBag.Title = "Viewbag title from controller";
       //     ViewBag.Header = "Viewbag header from controller";

       //     return View("EVE.Mvc.Samples.Embedded.Views.Sample.LandingPage.html", "EVE.Mvc.Samples.Embedded.Views.Sample.LandingPageMaster.html");
       // }
    //}
}
