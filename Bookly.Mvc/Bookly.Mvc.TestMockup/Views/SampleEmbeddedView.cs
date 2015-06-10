using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc.TestMockup.Views
{
    [EmbeddedView("Bookly.Mvc.TestMockup.Views.Mockup.index.cshtml")]
    public class SampleEmbeddedView : EmbeddedView
    {
        

        public override void ManipulateDocument(HtmlAgilityPack.HtmlDocument Document, System.Web.Mvc.ViewContext viewContext)
        {
            
        }
    }
}
