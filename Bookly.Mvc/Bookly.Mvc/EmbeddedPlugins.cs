using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc
{
    public static class EmbeddedPlugins
    {
        //Set up MEF container and select all that exports IEmbeddedPlugin and make a list of it
        public static void DiscoverPlugins()
        { }

        //run initialization code for each discovered plugin
        public static void InitializePlugins()
        {
 
        }


    }
}
