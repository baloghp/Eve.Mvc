using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.SimpleMaster
{
    [MasterView("eve-Assets.Views.Sample.SimpleMaster.LandingMaster.html")]
    [EmbeddedView("eve-Assets.Views.Sample.SimpleMaster.LandingPage.html")]
    public class PageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument
                .Document
                .SelectSingleNode("//title")
                .InnerHtml = "This title is defined in Master, but it has been changed in page view.";
        }
    }
}
