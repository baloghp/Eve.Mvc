using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Class representing a section in an EMbeddedView
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Gets or sets the name of the section
        /// </summary>
        /// <value>
        /// The name of the section
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether section should be rendered as if it has a renderinstead attribute.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [render instead]; otherwise, <c>false</c>.
        /// </value>
        public bool RenderInstead { get; set; }
        private List<string> _contents = null;
        /// <summary>
        /// Gets the contents for the section
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        public IList<string> Contents {
            get {
                return _contents ?? (_contents = new List<string>());
            }
        }
    }
}
