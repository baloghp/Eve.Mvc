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
using EVE.Mvc.ViewEngine;
using System.Web.UI;

namespace EVE.Mvc
{
    public abstract class EmbeddedView : EmbeddedView<dynamic>
    {
    }

    [InheritedExport]
    public abstract class EmbeddedView<T> : IModelContainer<T>, IView, IViewDataContainer
    {
        #region Model
        public T Model
        {
            get;
            protected set;
        }
        #endregion

        #region markup and internal html doc
        internal string RawMarkup { get; set; }
        private IDocumentHelper _htmlDocument = null;
        public IDocumentHelper HtmlDocument
        {
            get
            {
                return _htmlDocument;
            }
            private set
            {
                _htmlDocument = value;
            }
        }
        #endregion

        private const string NOMASTERVIEWNAME = "___NO___MASTER___DISCOVERED****YET"; //pretty unique, hope no-one will want to name their master view like this
        private string _masterName = NOMASTERVIEWNAME;
        public string MasterName
        {
            get
            {
                if (_masterName == NOMASTERVIEWNAME)
                {
                    _masterName = DiscoverMasterNameFromAttribute();
                }
                return _masterName;
            }
            internal set
            {
                _masterName = value;
            }
        }

        private string DiscoverMasterNameFromAttribute()
        {
            var masterViewAttribute = this.GetType().GetCustomAttributes(typeof(MasterViewAttribute), true).FirstOrDefault() as MasterViewAttribute;
            if (masterViewAttribute != null)
            {
                return masterViewAttribute.MasterViewName;
            }
            return null;
        }


        public string ViewName { get; internal set; }

        public string AssemblyName { get; internal set; }



        public ViewDataDictionary ViewData { get; set; }
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
            if (!(this.ViewData.Model is T))
            {
                throw new ApplicationException(String.Format("Model passed for this view MUST be of type:{0}, but it is {1}", typeof(T), this.ViewData.Model.GetType()));
            }
            this.Model = (T)this.ViewData.Model;
            this.ViewData = viewContext.ViewData;
            this.Html = new HtmlHelper(viewContext, this);

            //if it has a master prepare that
            if (!string.IsNullOrWhiteSpace(MasterName))
            {
                //get the html for the master view, by calling MVC view resolution
                var masterString = this.Html.Partial(MasterName, Model, this.ViewData);
                //let's prepare that as our main doc
                masterDoc = new HtmlDocument();
                masterDoc.LoadHtml(masterString.ToHtmlString());

                //let's see where to put the current view
                var renderBodyNode = masterDoc.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.RenderBody));
                //if we could not find the place there is trouble
                if (renderBodyNode == null)
                    throw new ApplicationException("Master does not define node with 'eve-renderbody' attribute");
                //let's see if we should render the current view into the tag, or instead
                // we put the raw markup in there
                if (renderBodyNode.Attributes.Contains(EveMarkupAttributes.RenderInstead))
                {
                    var parent = renderBodyNode.ParentNode;
                    parent.InnerHtml = parent.InnerHtml.Replace(renderBodyNode.OuterHtml, RawMarkup);
                }
                else
                {
                    renderBodyNode.InnerHtml = RawMarkup;
                }

                // and we make the masterdoc our current operating document
                HtmlDocument = new DocumentHelper(masterDoc);
            }
            else
            {
                //if there is no masterpage, we prepare the raw markup as the current document
                var doc = new HtmlAgilityPack.HtmlDocument();
                if (!String.IsNullOrWhiteSpace(RawMarkup))
                    doc.LoadHtml(RawMarkup);
                HtmlDocument = new DocumentHelper(doc);
            }
            //pass manipulation to child
            ProcessView(viewContext);

            //handle partial views
            var partialNodes = HtmlDocument.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.PartialView));
            if (partialNodes != null && partialNodes.Count() > 0)
            {
                foreach (var partialNode in partialNodes)
                {
                    //let's get the viewname
                    var partialName = partialNode.Attributes[EveMarkupAttributes.PartialView].Value;
                    //let's see if the user defined a model for this, by default we pass on the current model
                    object partialModel = Model;
                    if (partialNode.Attributes.Contains(EveMarkupAttributes.PartialModel))
                    {
                        var partialModelPath = partialNode.Attributes[EveMarkupAttributes.PartialModel].Value;
                        //eval the new partial model on the current one
                        partialModel = DataBinder.Eval(Model, partialModelPath);
                    }
                    //call partial MVC view process
                    var partialString = this.Html.Partial(partialName, partialModel, this.ViewData).ToHtmlString();
                    //determine if the partial result should be inside the partial tag or instead
                    if (partialNode.Attributes.Contains(EveMarkupAttributes.RenderInstead))
                    {
                        var parent = partialNode.ParentNode;
                        parent.InnerHtml = parent.InnerHtml.Replace(partialNode.OuterHtml, partialString);
                    }
                    else
                    {
                        partialNode.InnerHtml = partialString;
                    }
                }
            }



            //save doc to output stream
            HtmlDocument.Document.Save(writer);
        }

        public abstract void ProcessView(ViewContext viewContext);





    }
}
