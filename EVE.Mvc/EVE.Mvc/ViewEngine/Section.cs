using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public class Section
    {
        public string Name { get; set; }
        public bool RenderInstead { get; set; }
        private List<string> _contents = null;
        public IList<string> Contents {
            get {
                return _contents ?? (_contents = new List<string>());
            }
        }
    }
}
