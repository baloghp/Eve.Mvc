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

        bool ContainsAttribute(string renderInstead);
        void RenderInstead(string content);
        void RenderInto(string content);
        void Render(string content);
    }
}
