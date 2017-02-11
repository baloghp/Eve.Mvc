using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocumentNode : IDocumentNode
    {
        private HtmlNode Node;

        public HADocumentNode(HtmlNode node)
        {
            this.Node = node;
        }

        public string InnerHtml
        {
            get
            {
                return Node.InnerHtml;
            }

            set
            {
                this.Node.InnerHtml=value;
            }
        }

        public string OuterHtml
        {
            get
            {
                return Node.OuterHtml;
            }

           
        }

        public IDocumentNode ParentNode
        {
            get
            {
                return new HADocumentNode(Node.ParentNode);
            }
        }

        public bool ContainsAttribute(string attributeName)
        {
            return Node.Attributes.Contains(attributeName);
        }

        public string GetAttributeValue(string attributeName)
        {
            return Node.Attributes[attributeName].Value;
        }

        public void Remove()
        {
            Node.Remove();
        }

        public void RemoveAttribute(string attributeName)
        {
            Node.Attributes.Remove(attributeName);
        }

        public void Render(string content)
        {
            Node.InnerHtml = content;
        }

        public void RenderInstead(string content)
        {
            var parent = Node.ParentNode;
            parent.InnerHtml = parent.InnerHtml.Replace(Node.OuterHtml, content);
        }

        public void RenderInto(string content)
        {
            Node.InnerHtml += content;
        }
    }
}
