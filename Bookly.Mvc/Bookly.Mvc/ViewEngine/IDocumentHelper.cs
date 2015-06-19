using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{
    public interface IDocumentHelper
    {
        HtmlAgilityPack.HtmlDocument Document { get; }
       
    }
}
