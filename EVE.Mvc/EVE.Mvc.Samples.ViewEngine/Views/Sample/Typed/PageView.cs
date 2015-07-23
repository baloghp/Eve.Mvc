using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.DocumentHelperExtensions;
using EVE.Mvc.Samples.ViewEngine.Models;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Typed
{
    [MasterView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Typed.LandingMaster.html")]
    [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Typed.LandingPage.html")]
    public class PageView : EmbeddedView<LandingPageModel>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument.ProcessBundles();
            this.HtmlDocument
               .Document
               .DocumentNode
               .SelectSingleNode("//title")
               .InnerHtml = String.Format("Type of the Model of this View is: {0}, and it is not null (true/false): {1}", Model.GetType(), Model!=null) ;
        }
    }
}
