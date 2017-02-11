using EVE.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EVE.MVC.Xml
{
    public class EVEXDocument : XmlDocument, IDocument
    {
        public string InnerHtml
        {
            get
            {
                return this.DocumentElement.InnerXml;
            }

            set
            {
                this.DocumentElement.InnerXml = value;
            }
        }

        public string OuterHtml
        {
            get
            {
                return this.DocumentElement.OuterXml;
            }
        }

        IDocumentNode IDocumentNode.ParentNode
        {
            get
            {
                return null;
            }
        }

        public bool ContainsAttribute(string attributeName)
        {
            return DocumentElement.HasAttribute(attributeName);
        }

        public string GetAttributeValue(string attributeName)
        {
            return DocumentElement.GetAttribute(attributeName);
        }

        public void LoadHtml(string v)
        {
            base.LoadXml(v);
        }

        public void Remove()
        {
            DocumentElement.RemoveAll();
        }

        public void RemoveAttribute(string attributeName)
        {
            DocumentElement.RemoveAttribute(attributeName);
        }

        public void Render(string content)
        {
            DocumentElement.InnerXml = content;
        }

        public void RenderInstead(string content)
        {
            // on document level this is the same as renewing the doc
            this.LoadHtml(content);
        }

        public void RenderInto(string content)
        {
            DocumentElement.InnerXml += content;
        }

        IEnumerable<IDocumentNode> IDocument.SelectNodes(string xpath)
        {
            var nodes = DocumentElement.SelectNodes(xpath);
            if (nodes == null) return null;
            var list = new List<EVEXDocumentNode>();
            foreach (XmlNode item in nodes)
            {
                list.Add(new EVEXDocumentNode(item));
            }

            return list;
        }

        IDocumentNode IDocument.SelectSingleNode(string xpath)
        {
            var node = DocumentElement.SelectSingleNode(xpath);
            if (node == null) return null;
            return new EVEXDocumentNode(node);
        }
    }
}
