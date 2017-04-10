using EVE.Mvc;
using EVE.Mvc.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.MVC.Xml
{
    public class EVEXDocumentHelperFactory : BaseDocumentHelperFactory
    {
        public override IDocument CreateDocument()
        {
            return new EVEXDocument();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper()
        {
            return new EVEXDocumentHelper();
        }

        public override IDocumentHelper<IDocument> CreateDocumentHelper(IDocument document)
        {
            return new EVEXDocumentHelper(document);
        }
    }
}
