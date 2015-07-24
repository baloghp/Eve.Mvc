using EVE.Mvc.ViewEngine;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{
   public class DocumentHelper : IDocumentHelper
    {
       HtmlAgilityPack.HtmlDocument _document;
        public HtmlAgilityPack.HtmlDocument Document
        {
            get { return _document; }
        }


       public DocumentHelper(HtmlDocument document)
       {
           _document = document;
       }

       internal void CleanUp()
       {
           _document = null;
       }

       
    }
}
