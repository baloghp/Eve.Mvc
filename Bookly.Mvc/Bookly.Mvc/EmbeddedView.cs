using RazorEngine.Templating;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Razor.Parser;
using System.Dynamic;
using RazorEngine.Configuration;
using System.IO;
using System.Web.Mvc.Razor;
using System.ComponentModel.Composition;
using HtmlAgilityPack;

namespace Bookly.Mvc
{
    [InheritedExport]
    public abstract class EmbeddedView: IView
    {
        public string ViewName { get; internal set; }
        public string AssemblyName { get; internal set; }
        public ControllerContext ControllerContext { get; internal set; }
        public HtmlDocument Document { get; internal set; }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            Document = new HtmlAgilityPack.HtmlDocument();
            var html = AssetManager.LoadResourceString(ViewName,AssemblyName);
            Document.LoadHtml(html);

            ManipulateDocument(Document, viewContext);

            Document.Save(writer);
        }

        public abstract void ManipulateDocument(HtmlDocument Document, ViewContext viewContext);
       
    }
}
