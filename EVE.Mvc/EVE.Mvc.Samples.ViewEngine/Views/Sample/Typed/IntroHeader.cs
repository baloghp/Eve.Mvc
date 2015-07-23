using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample.Typed
{
   [EmbeddedView("eve-EVE.Mvc.Samples.ViewEngine.Assets.Views.Sample.Typed.IntroHeader.html")]
    public class IntroHeader:EmbeddedView<Models.IntroHeader>
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument
               .Document
               .DocumentNode
               .SelectSingleNode("//h1")
               .InnerHtml = String.Format("Type of the Model of this View is: {0}, and it is not null (true/false): {1}", Model.GetType(), Model != null);
        }
    }
}
