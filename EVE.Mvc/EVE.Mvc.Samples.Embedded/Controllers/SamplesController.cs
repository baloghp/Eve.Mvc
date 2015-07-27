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
           
            return View("/EVE.Mvc.Samples.Embedded/Views/Sample/index.cshtml");

        }
    }
      

     
    
}
