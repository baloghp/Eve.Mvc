//using EVE.Mvc;

//namespace EVE.Mvc
//{
//    /// <summary>
//    /// Interface that defines a documenthelper that the Embedded View can use. It exposes an HtmlDocument that can be manipulated in the view code.
//    /// It also serves the function of providing the basis of document manipulation extensions, such as bundles, localization, databinding etc...
//    /// See documentation for the extension pattern
//    /// </summary>
//    public class DocumentHelper : IDocumentHelper
//    {
//       HtmlAgilityPack.HtmlDocument _document;
//       /// <summary>
//       /// Gets the HtmlAgilityPack.HtmlDocument that contains the view's markup.
//       /// </summary>
//       /// <value>
//       /// The document.
//       /// </value>
//        public HtmlAgilityPack.HtmlDocument Document
//        {
//            get { return _document; }
//        }


//        /// <summary>
//        /// Initializes a new instance of the <see cref="DocumentHelper"/> class.
//        /// </summary>
//        /// <param name="document">The document.</param>
//       public DocumentHelper(HtmlDocument document)
//       {
//           _document = document;
//       }

//       /// <summary>
//       /// Cleans up internal document.
//       /// </summary>
//       internal void CleanUp()
//       {
//           _document = null;
//       }

       
//    }
//}
