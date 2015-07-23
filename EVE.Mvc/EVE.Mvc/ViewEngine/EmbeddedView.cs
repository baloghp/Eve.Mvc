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


    public abstract class EmbeddedView<T> : IModelContainer<T>, IEmbeddedView
    {
        #region Model
        private T _model;
        public T Model
        {
            get
            {
                if (_model == null)
                {
                    if (this.ViewData.Model != null && !(this.ViewData.Model is T))
                    {
                        throw new ApplicationException(String.Format("Model passed for this view MUST be of type:{0}, but it is {1}", typeof(T), this.ViewData.Model.GetType()));
                    }
                    _model = (T)this.ViewData.Model;
                }
                return _model;
            }
            protected set
            {
                _model = value;
            }
        }
        #endregion

        #region markup and internal html doc
        public string RawMarkup { get; set; }
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

        #region mastername
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
            set
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
        #endregion

        #region sections
        private List<Section> _sections;
        public IList<Section> Sections
        {
            get
            {
                return _sections ?? (_sections = new List<Section>());
            }
        }
        #endregion

        public string ViewName { get; set; }
        public ViewDataDictionary ViewData { get; set; }
        public HtmlHelper Html { get; internal set; }

        public EmbeddedView()
        {
            this.ViewData = new ViewDataDictionary();
        }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {

            HtmlDocument document;

            //init context sensitive fields
            this.ViewData = viewContext.ViewData;
            this.Html = new HtmlHelper(viewContext, this);

            //if it has a master prepare that
            if (!string.IsNullOrWhiteSpace(MasterName))
            {
                PrepareMasterPage();
            }
            else
            {
                //if there is no masterpage, we prepare the raw markup as the current document
                var doc = new HtmlAgilityPack.HtmlDocument();
                if (!String.IsNullOrWhiteSpace(RawMarkup))
                    doc.LoadHtml(RawMarkup);
                HtmlDocument = new DocumentHelper(doc);
            }


            //handle partial views
            
            var partialNode = HtmlDocument.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.PartialView));
            while (partialNode!=null)
            {
                HandlePartials(partialNode);
                partialNode = HtmlDocument.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.PartialView));
            }
            

            // collect sections
            // only when the page view is called, not during master or partial
            if (this == viewContext.View)
            {
                CreateSections();
            }

            //pass manipulation to child
            ProcessView(viewContext);

            // set sectionContent to html
            // only when the page view is called, not during master or partial
            if (this == viewContext.View)
            {
                ProcessSections();
            }

            //save doc to output stream
            HtmlDocument.Document.Save(writer);
        }

        private void ProcessSections()
        {
            foreach (var section in Sections)
            {
                var sectionNode = HtmlDocument.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeByValueQuery(EveMarkupAttributes.SectionDefinition, section.Name));
                if (sectionNode != null)
                {
                    var content = string.Concat(section.Contents);
                    RenderForNode(sectionNode, content);
                }
            }
        }

        private void CreateSections()
        {
            var sectionDefinitions = HtmlDocument.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.SectionDefinition));
            if (sectionDefinitions != null)
            {
                Sections.Clear();
                foreach (var item in sectionDefinitions)
                {
                    string sectionName = item.Attributes[EveMarkupAttributes.SectionDefinition].Value;
                    if (Sections.Where(s => s.Name == sectionName).Count() > 0)
                        throw new ApplicationException(String.Format("Duplicate section definition: {0}", sectionName));

                    Section section = new Section()
                    {
                        Name = item.Attributes[EveMarkupAttributes.SectionDefinition].Value,
                        RenderInstead = item.Attributes[EveMarkupAttributes.RenderInstead] != null
                    };
                    var sectionContents = HtmlDocument.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeByValueQuery(EveMarkupAttributes.SectionContentFor, sectionName));
                    if (sectionContents != null)
                    {
                        foreach (var sectionContentNode in sectionContents)
                        {
                            if (sectionContentNode.Attributes[EveMarkupAttributes.RenderOnlyContent] == null)
                            {
                                section.Contents.Add(sectionContentNode.OuterHtml);
                            }
                            else
                            {
                                section.Contents.Add(sectionContentNode.InnerHtml);
                            }
                            sectionContentNode.Remove();
                        }

                    }

                    Sections.Add(section);
                }
            }
        }

        private void HandlePartials(HtmlNode partialNode)
        {

            //let's get the view name
            var partialName = partialNode.Attributes[EveMarkupAttributes.PartialView].Value;
            //let's see if the user defined a model for this, by default we pass on the current model
            object partialModel = Model;
            if (partialNode.Attributes.Contains(EveMarkupAttributes.PartialModel))
            {
                var partialModelPath = partialNode.Attributes[EveMarkupAttributes.PartialModel].Value;
                //eval the new partial model on the current one
                if (Model != null && !string.IsNullOrWhiteSpace(partialModelPath))
                    partialModel = DataBinder.Eval(Model, partialModelPath);
            }
            //call partial MVC view process
            var viewData = new ViewDataDictionary(this.ViewData);
            viewData.Model = partialModel;
            var partialString = this.Html.Partial(partialName, partialModel, viewData).ToHtmlString();
            partialNode.Attributes.Remove(EveMarkupAttributes.PartialView);
            //determine if the partial result should be inside the partial tag or instead
            RenderForNode(partialNode, partialString);
            
            

        }

        private HtmlAgilityPack.HtmlDocument PrepareMasterPage()
        {
            //get the html for the master view, by calling MVC view resolution
            var masterString = this.Html.Partial(MasterName, Model, this.ViewData);
            //let's prepare that as our main doc
            var masterDoc = new HtmlDocument();
            masterDoc.LoadHtml(masterString.ToHtmlString());

            //let's see where to put the current view
            var renderBodyNode = masterDoc.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQuery(EveMarkupAttributes.RenderBody));
            //if we could not find the place there is trouble
            if (renderBodyNode == null)
                throw new ApplicationException("Master does not define node with 'eve-renderbody' attribute");
            //let's see if we should render the current view into the tag, or instead
            // we put the raw markup in there
            RenderForNode(renderBodyNode, RawMarkup);

            // and we make the masterdoc our current operating document
            HtmlDocument = new DocumentHelper(masterDoc);
            return masterDoc;
        }
        /// <summary>
        /// Renders content for node considering renderinstead, and renderinto attributes
        /// </summary>
        /// <param name="renderNode"></param>
        /// <param name="content"></param>
        public static void RenderForNode(HtmlNode renderNode, string content)
        {
            //let's see if we should render the current view into the tag, or instead
            // we put the raw markup in there
            if (renderNode.Attributes.Contains(EveMarkupAttributes.RenderInstead))
            {
                var parent = renderNode.ParentNode;
                parent.InnerHtml = parent.InnerHtml.Replace(renderNode.OuterHtml, content);
            }
            else if (renderNode.Attributes.Contains(EveMarkupAttributes.RenderInto))
            {
                renderNode.InnerHtml += content;
            }
            else
            {
                renderNode.InnerHtml = content;
            }

        }

        public abstract void ProcessView(ViewContext viewContext);


        public void CleanUp()
        {
            var documentHelper = this.HtmlDocument as DocumentHelper;
            if (documentHelper != null) documentHelper.CleanUp();

            this.HtmlDocument = null;

        }
    }
}
