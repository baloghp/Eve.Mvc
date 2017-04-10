using EVE.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocumentHelper : Mvc.IDocumentHelper<IDocument>
    {
        private IDocument document;

        public HADocumentHelper()
        {
            document = new HADocument();
        }

        public HADocumentHelper(IDocument document)
        {
            this.document = document;
        }

        public IDocument Document
        {
            get
            {
                return document;
            }
        }

        public void CleanUp()
        {
            this.document = null;
        }
    }
}
