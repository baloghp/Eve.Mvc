using EVE.Mvc.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HtmlAgilityDocumentHelperFactory : BaseDocumentHelperFactory
    {
        public override Mvc.IDocument CreateDocument()
        {
            throw new NotImplementedException();
        }

        public override Mvc.IDocumentHelper<T> CreateDocumentHelper<T>()
        {
            throw new NotImplementedException();
        }

        public override Mvc.IDocumentHelper<T> CreateDocumentHelper<T>(T document)
        {
            throw new NotImplementedException();
        }
    }
}
