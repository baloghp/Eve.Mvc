using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class MasterViewAttribute : Attribute
    {
        readonly string masterViewName;

        // This is a positional argument
        public MasterViewAttribute(string maserViewName)
        {
            this.masterViewName = maserViewName;


        }

        public string MasterViewName
        {
            get { return masterViewName; }
        }


    }

}
