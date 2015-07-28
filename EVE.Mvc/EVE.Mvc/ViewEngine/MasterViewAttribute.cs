using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Attribute to signal the required Master view for a page view.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class MasterViewAttribute : Attribute
    {
        readonly string masterViewName;


        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewAttribute"/> class.
        /// </summary>
        /// <param name="maserViewName">Name of the maser view.</param>
        public MasterViewAttribute(string maserViewName)
        {
            this.masterViewName = maserViewName;


        }

        /// <summary>
        /// Gets the name of the master view.
        /// </summary>
        /// <value>
        /// The name of the master view.
        /// </value>
        public string MasterViewName
        {
            get { return masterViewName; }
        }


    }

}
