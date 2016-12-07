using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.MasterAndPartials
{
    [MasterView("eve-Assets.Views.Sample.SimpleMaster.LandingMaster.html")]
    [EmbeddedView("eve-Assets.Views.Sample.MasterAndPartials.LandingPage.html")]
    public class PageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            var nodes = this.HtmlDocument
                            .Document
                            .SelectNodes("//h2");
            foreach (var item in nodes)
            {
                item.InnerHtml = "Partial view content changed by page view";
            }

        }
    }
}
