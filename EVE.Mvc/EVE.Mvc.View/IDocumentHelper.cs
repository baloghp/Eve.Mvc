﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{
    /// <summary>
    /// Interface defining HtmlDocument for view processing.
    /// </summary>
    public interface IDocumentHelper
    {
        /// <summary>
        /// Gets the HtmlDocument.
        /// </summary>
        /// <value>
        /// The document.
        /// </value>
        HtmlAgilityPack.HtmlDocument Document { get;}
       
    }
}