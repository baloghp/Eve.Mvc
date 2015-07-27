using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
namespace EVE.Mvc.ViewEngine
{

   
    public interface IEmbeddedView : IView, IViewDataContainer
    {
        System.Web.Mvc.HtmlHelper Html { get; }
        EVE.Mvc.IDocumentHelper HtmlDocument { get; }
        string MasterName { get; set; }
        string RawMarkup { get; set; }
        void ProcessView(System.Web.Mvc.ViewContext viewContext);
        System.Collections.Generic.IList<Section> Sections { get; }
        string ViewName { get; set; }
        void CleanUp();
    }
}
