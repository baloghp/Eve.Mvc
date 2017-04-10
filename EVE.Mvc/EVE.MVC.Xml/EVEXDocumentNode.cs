using EVE.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EVE.MVC.Xml
{
    public class EVEXDocumentNode : IDocumentNode
    {
        private XmlNode Node;

        public EVEXDocumentNode(XmlNode node)
        {
            this.Node = node;
        }

        public string InnerHtml
        {
            get
            {
                return Node.InnerXml;
            }

            set
            {
                this.Node.InnerXml = value;
            }
        }


        public string OuterHtml
        {
            get
            {
                return Node.OuterXml;
            }


        }

        public IDocumentNode ParentNode
        {
            get
            {
                return new EVEXDocumentNode(Node.ParentNode);
            }
        }


        public bool ContainsAttribute(string attributeName)
        {
            return Node.Attributes[attributeName] != null;
        }

        public string GetAttributeValue(string attributeName)
        {
            return Node.Attributes[attributeName].Value;
        }

        public void Remove()
        {
            Node.ParentNode.RemoveChild(Node);
        }

        public void RemoveAttribute(string attributeName)
        {
            var attr = Node.Attributes[attributeName];
            if (attr == null) return;
            Node.Attributes.Remove(attr);
        }

        public void Render(string content)
        {
            Node.InnerXml = content;
        }

        public void RenderInstead(string content)
        {
            var parent = Node.ParentNode;
            parent.InnerXml = parent.InnerXml.Replace(Node.OuterXml, content);
        }

        public void RenderInto(string content)
        {
            Node.InnerXml += content;
        }
    }
}
