using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Providers
{
    public abstract class BaseDocumentHelperFactory : ProviderBase
    {
        public abstract IDocumentHelper<IDocument> CreateDocumentHelper();
        public abstract IDocumentHelper<IDocument> CreateDocumentHelper(IDocument document);
        public abstract IDocument CreateDocument();
    }
}
