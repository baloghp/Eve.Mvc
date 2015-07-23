using Microsoft.Owin.FileSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    
    public class EmbeddedFileSystem :  EmbeddedResourceFileSystem
    {
        /// <summary>
        /// EmbeddedPathProvider needs phisical file path for CacheDependancy
        /// We're using this property to pass on the assembly's location
        /// </summary>
        public string AssemblyPath { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using the calling
        /// assembly and empty base namespace.
        /// </summary>
        public EmbeddedFileSystem()
            : this(Assembly.GetCallingAssembly())
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
            AssemblyPath = assembly.Location;
        }

        public EmbeddedFileSystem(Assembly assembly, string baseNamespace)
            : base(assembly, baseNamespace)
        {
            AssemblyPath = assembly.Location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using the calling
        /// assembly and specified base namespace.
        /// </summary>
        /// <param name="baseNamespace">The base namespace that contains the embedded resources.</param>
        public EmbeddedFileSystem(string baseNamespace)
            : this(Assembly.GetCallingAssembly(), baseNamespace)
        {
           
        }

       /// <summary>
       /// Initializes a new instance of the <see cref="EmbeddedFileSystem" /> class using 
       /// assembly fullname and specified base namespace.
       /// </summary>
       /// <param name="assemblyName"></param>
       /// <param name="baseNamespace"></param>

        public EmbeddedFileSystem(string assemblyName, string baseNamespace)
            : this(GetAssemblyByName(assemblyName), baseNamespace)
        { 
            
        }
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
