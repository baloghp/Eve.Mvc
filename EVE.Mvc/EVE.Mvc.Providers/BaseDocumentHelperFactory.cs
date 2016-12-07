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
        public abstract IDocumentHelper<T> CreateDocumentHelper<T>() where T : IDocument;
        public abstract IDocumentHelper<T> CreateDocumentHelper<T>(T document) where T : IDocument;
        public abstract IDocument CreateDocument();
    }
}
