using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Mvc.ViewEngine;
using EVE.Mvc.Samples.ViewEngine.L10N;
using System.Globalization;
using System.Threading;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Bundles
{
    [MasterView("eve-Assets.Views.Sample.Bundles.LandingMaster.html")]
    [EmbeddedView("eve-Assets.Views.Sample.Bundles.LandingPage.html")]
    public class PageView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument.ProcessBundles().ProcessLocals(Resources.ResourceManager, Thread.CurrentThread.CurrentUICulture);

        }
    }
}
