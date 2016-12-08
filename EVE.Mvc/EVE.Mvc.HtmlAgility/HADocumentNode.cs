using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocumentNode : IDocumentNode
    {
        public string InnerHtml
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string OuterHtml
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IDocumentNode ParentNode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ContainsAttribute(string renderInstead)
        {
            throw new NotImplementedException();
        }

        public string GetAttributeValue(string attributeName)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void RemoveAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public void Render(string content)
        {
            throw new NotImplementedException();
        }

        public void RenderInstead(string content)
        {
            throw new NotImplementedException();
        }

        public void RenderInto(string content)
        {
            throw new NotImplementedException();
        }
    }
}
