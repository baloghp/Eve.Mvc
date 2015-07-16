using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Views.Sample
{
    [EmbeddedView("eve-Just.Code.Simple.Html.View")]
    public class SimpleHtmlView : EmbeddedView
    {
        public override void ProcessView(System.Web.Mvc.ViewContext viewContext)
        {
            this.HtmlDocument.Document.LoadHtml(@"<html>
                                                    <body>
                                                    Hello World!!!
                                                    </body>
                                                    </html>                                                    ");
        }
    }
}
