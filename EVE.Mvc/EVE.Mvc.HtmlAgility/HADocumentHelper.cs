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
