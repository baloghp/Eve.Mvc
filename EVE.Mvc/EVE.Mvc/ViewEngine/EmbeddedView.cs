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
using System.Web.Mvc.Html;

namespace EVE.Mvc
{
    [InheritedExport]
    public abstract class EmbeddedView: IView, IViewDataContainer
    {
        public string ViewName { get; internal set; }
        public string MasterName { get; set; }
        public string AssemblyName { get; internal set; }
        
        //public HtmlDocument Document { get; internal set; }
        public IDocumentHelper HtmlDocument { get; internal set; }
        public ViewDataDictionary ViewData  { get; set; }
        public HtmlHelper Html { get; internal set; }

        public EmbeddedView()
        {
            this.ViewData = new ViewDataDictionary();
        }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            HtmlDocument masterDoc = null;
            HtmlDocument document;

            //init context sensitive fields
            this.ViewData = viewContext.ViewData;    
            this.Html = new HtmlHelper(viewContext,this);

            //if it has a master prepare that
            if (!string.IsNullOrWhiteSpace(MasterName))
            {
                var masterString = this.Html.Partial(MasterName);
                masterDoc = new HtmlDocument();
                masterDoc.LoadHtml(masterString.ToHtmlString());
               
            }

            //prepare document for the current view
            document = new HtmlAgilityPack.HtmlDocument();
            var html = AssetManager.LoadResourceString(ViewName,AssemblyName);
            document.LoadHtml(html);
            //init document helper
            this.HtmlDocument = new DocumentHelper(document);


            //pass manipulation to child
            ProcessView(viewContext);

            //handle partial views

            //handle masterpage, if we have one insert the doc into it.
            if (masterDoc!=null)
            {
                masterDoc.DocumentNode.SelectSingleNode("//*[@ev-renderbody]").InnerHtml = document.DocumentNode.WriteTo();
                masterDoc.Save(writer);
                return;
            }


            //save doc to output stream
            document.Save(writer);
        }

        public abstract void ProcessView(ViewContext viewContext);


        
    }
}
