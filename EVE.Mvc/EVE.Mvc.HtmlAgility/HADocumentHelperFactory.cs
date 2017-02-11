using EVE.Mvc.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocumentHelperFactory : BaseDocumentHelperFactory
    {
        public override Mvc.IDocument CreateDocument()
        {
            return new HADocument();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper()
        {
            return new HADocumentHelper();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper(IDocument document)
        {
            return new HADocumentHelper(document);
        }
    }
}
