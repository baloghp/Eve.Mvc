using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc

{
    public interface IDocumentNode
    {
        IDocumentNode ParentNode { get; }
        string OuterHtml { get; set; }
        string InnerHtml { get; set; }

        bool ContainsAttribute(string renderInstead);
        void RenderInstead(string content);
        void RenderInto(string content);
        void Render(string content);
        void RemoveAttribute(string attributeName);
        string GetAttributeValue(string attributeName);
        void Remove();
    }
}
