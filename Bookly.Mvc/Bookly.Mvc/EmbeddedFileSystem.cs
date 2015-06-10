using Microsoft.Owin.FileSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc
{
    /// <summary>
    /// This class is obsolete you should use Microsoft.Owin.FileSystems.EmbeddedResourceFileSystem
    /// </summary>
    
    public class EmbeddedFileSystem :  EmbeddedResourceFileSystem
    {
          
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using the calling
        /// assembly and empty base namespace.
        /// </summary>
        public EmbeddedFileSystem()
            : base(Assembly.GetCallingAssembly())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using the specified
        /// assembly and empty base namespace.
        /// </summary>
        /// <param name="assembly"></param>
        public EmbeddedFileSystem(Assembly assembly)
            : base(assembly, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using the calling
        /// assembly and specified base namespace.
        /// </summary>
        /// <param name="baseNamespace">The base namespace that contains the embedded resources.</param>
        public EmbeddedFileSystem(string baseNamespace)
            : base(Assembly.GetCallingAssembly(), baseNamespace)
        {
        }

       /// <summary>
       /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using 
       /// assembly fullname and specified base namespace.
       /// </summary>
       /// <param name="assemblyName"></param>
       /// <param name="baseNamespace"></param>

        public EmbeddedFileSystem(string assemblyName, string baseNamespace)
            : base(GetAssemblyByName(assemblyName), baseNamespace) 
        { }
        /// <summary>
        /// Finds the assembly in the current AppDomain based on assemblies fullname
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Assembly GetAssemblyByName(string assemblyName)
        {
            return (from a in AppDomain.CurrentDomain.GetAssemblies()
                       where a.FullName == assemblyName
                       select a).FirstOrDefault();
            
        }
        

    }
}
