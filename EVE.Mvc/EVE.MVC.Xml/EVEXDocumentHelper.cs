using EVE.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.MVC.Xml
{
    public class EVEXDocumentHelper : Mvc.IDocumentHelper<IDocument>
    {
        private IDocument document;

        public EVEXDocumentHelper()
        {
            document = new EVEXDocument();
        }

        public EVEXDocumentHelper(IDocument document)
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
