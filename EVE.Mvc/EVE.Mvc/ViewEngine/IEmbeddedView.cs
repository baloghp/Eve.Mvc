using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
namespace EVE.Mvc.ViewEngine
{


    /// <summary>
    /// Interface of EmbeddedView to establish non generic based MEF export. Also here is listed all necessary parts of an EmbeddedView.
    /// Plus it has all necessary View related ancestor interfaces.
    /// </summary>
    public interface IEmbeddedView : IView, IViewDataContainer
    {

        IViewEngine ViewEngine { get; set; }
        /// <summary>
        /// Gets the HTML helper.
        /// </summary>
        /// <value>
        /// The HTML.
        /// </value>
        System.Web.Mvc.HtmlHelper Html { get; }
        /// <summary>
        /// Gets the HTML document.
        /// </summary>
        /// <value>
        /// The HTML document.
        /// </value>
        EVE.Mvc.IDocumentHelper HtmlDocument { get; }
        /// <summary>
        /// Gets or sets the name of the master.
        /// </summary>
        /// <value>
        /// The name of the master.
        /// </value>
        string MasterName { get; set; }
        /// <summary>
        /// Gets or sets the raw markup.
        /// </summary>
        /// <value>
        /// The raw markup.
        /// </value>
        string RawMarkup { get; set; }
        /// <summary>
        /// Override this in your view to process the view's document.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        void ProcessView(System.Web.Mvc.ViewContext viewContext);
        /// <summary>
        /// Gets the list of sections defined in the markup.
        /// </summary>
        /// <value>
        /// The sections.
        /// </value>
        System.Collections.Generic.IList<Section> Sections { get; }
        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        /// <value>
        /// The name of the view.
        /// </value>
        string ViewName { get; set; }
        /// <summary>
        /// Cleans up internal resource intensive objects such as the document.
        /// </summary>
        void CleanUp();

        void SetModel(object Model);
    }
}
