using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    public interface IModelContainer<T>
    {
         T Model { get;  }

    }
}
