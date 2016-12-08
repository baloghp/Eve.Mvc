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
            return new HADocument();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper()
        {
            return (IDocumentHelper<IDocument>)new HADocumentHelper();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper(IDocument document)
        {
            return (IDocumentHelper<IDocument>)new HADocumentHelper(document);
        }
    }
}
