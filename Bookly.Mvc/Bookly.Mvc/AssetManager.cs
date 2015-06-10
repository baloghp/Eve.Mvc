using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Mvc
{
    /// <summary>
    /// Assetmanager is a utility class containing helper functions
    /// to extract embedded resources
    /// </summary>
   public class AssetManager
    {
       /// <summary>
       /// Extracts resource string from an assembly defined by the assembly's full name
       /// </summary>
       /// <param name="name">resource's name to extract</param>
       /// <param name="assemblyName">fullname of the assembly</param>
       /// <returns></returns>
        internal static string LoadResourceString(string name, string assemblyName)
        {
            string value;
                var assembly = (from a in AppDomain.CurrentDomain.GetAssemblies()
                                where a.FullName == assemblyName
                                select a).FirstOrDefault();
                if (assembly == null) return string.Empty;
                using (var sr = new StreamReader(assembly.GetManifestResourceStream(name)))
                {
                    value = sr.ReadToEnd();
                }
            return value;
        }
       /// <summary>
        /// Extracts resource string from an assembly
       /// </summary>
       /// <param name="name">name of the resource</param>
       /// <param name="assembly">Assmebly containing the resource</param>
       /// <returns></returns>
        internal static string LoadResourceString(string name, Assembly assembly)
        {
            string value;
                if (assembly == null) return string.Empty;
                using (var sr = new StreamReader(assembly.GetManifestResourceStream(name)))
                {
                    value = sr.ReadToEnd();
                }
            return value;
        }
       /// <summary>
       /// Using reflection it creates a dictionary of an object's properties
       /// </summary>
       /// <param name="values">object to create map dictionary from</param>
       /// <returns></returns>
        public static IDictionary<string, object> Map(object values)
        {
            var dictionary = values as IDictionary<string, object>;

            if (dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    dictionary.Add(descriptor.Name, descriptor.GetValue(values));
                }
            }

            return dictionary;
        }
       /// <summary>
       /// Extracts and saves an embedded resource to the combined path of basePath and modulepath
       /// </summary>
       /// <param name="resourceName">name of the resource</param>
       /// <param name="assemblyName"> name of the assembly</param>
       /// <param name="basePath">base part of the path to save the resource</param>
       /// <param name="modulePath">module part of the path to save te resource</param>
        public static void ExtractResource(string resourceName, string assemblyName, string basePath, string modulePath)
        {
            string path = Path.Combine(basePath, modulePath);
            using (var f = File.Create(path))
            {
                using (StreamWriter sw  = new StreamWriter(f))
                {
                    sw.Write(LoadResourceString(resourceName , assemblyName));
                    sw.Flush();
                }
            }
        }
        /// <summary>
        /// Extracts and saves an embedded resource to the combined path of basePath and modulepath
        /// </summary>
        /// <param name="resourceName">name of the resource</param>
        /// <param name="assemblyName">the assembly</param>
        /// <param name="basePath">base part of the path to save the resource</param>
        /// <param name="modulePath">module part of the path to save te resource</param>
        public static void ExtractResource(string resourceName, Assembly assembly, string basePath, string modulePath)
        {
            string path = Path.Combine(basePath, modulePath);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "index.cshtml");
            using (var f = File.Create(path))
            {
                using (StreamWriter sw = new StreamWriter(f))
                {
                    sw.Write(LoadResourceString(resourceName, assembly));
                    sw.Flush();
                }
            }
        }
    }
}
