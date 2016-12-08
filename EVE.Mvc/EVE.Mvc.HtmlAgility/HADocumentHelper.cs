using EVE.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.HtmlAgility
{
    public class HADocumentHelper : Mvc.IDocumentHelper<HADocument>
    {
        private IDocument document;

        public HADocumentHelper()
        {
        }

        public HADocumentHelper(IDocument document)
        {
            this.document = document;
        }

        public HADocument Document
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void CleanUp()
        {
            throw new NotImplementedException();
        }
    }
}
