using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.ViewEngine
{
    /// <summary>
    /// Defines a contract to have a Model of type T in the class.
    /// </summary>
    /// <typeparam name="T">Type of the Model</typeparam>
    internal interface IModelContainer<T>
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        T Model { get; set; }

        

    }
}
