using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocument : HtmlDocument, IDocument
    {
        public string InnerHtml
        {
            get
            {
                return DocumentNode.InnerHtml;
            }

            set
            {
                DocumentNode.InnerHtml = value;
            }
        }

        public string OuterHtml
        {
            get
            {
                return DocumentNode.OuterHtml;
            }

          
        }

        public IDocumentNode ParentNode
        {
            get
            {
                return null;
            }
        }

        public bool ContainsAttribute(string attributeName)
        {
            return DocumentNode.Attributes.Contains(attributeName);
        }

        public string GetAttributeValue(string attributeName)
        {
            return DocumentNode.Attributes[attributeName].Value;
        }

        public new void LoadHtml(string html)
        {
            base.LoadHtml(html);             
        }

        public void Remove()
        {
            DocumentNode.Remove();
        }

        public void RemoveAttribute(string attributeName)
        {
            DocumentNode.Attributes.Remove(attributeName);
        }

        public void Render(string content)
        {
            DocumentNode.InnerHtml = content;
        }
        /// <summary>
        /// On Document level this is the same as loadhtml.
        /// </summary>
        /// <param name="content"></param>
        public void RenderInstead(string content)
        {
            // on document level this is the same as renewing the doc

            //throw new NotImplementedException();

            this.LoadHtml(content);
        }

        public void RenderInto(string content)
        {
            DocumentNode.InnerHtml += content;
        }

        public new void Save(TextWriter writer)
        {
            base.Save(writer);
        }

        public IEnumerable<IDocumentNode> SelectNodes(string xpath)
        {
            var nodes = DocumentNode.SelectNodes(xpath);
            if (nodes == null) return null;

            return from a in nodes
                   select new HADocumentNode(a);
        }

        public IDocumentNode SelectSingleNode(string xpath)
        {
            var node = DocumentNode.SelectSingleNode(xpath);
            if (node == null) return null;
            return new HADocumentNode(node);
        }
    }
}
