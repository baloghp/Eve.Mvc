using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace EVE.Mvc.Embedded
{
    public class EmbeddedPathProvider : VirtualPathProvider
    {

        internal readonly EmbeddedFileSystem embeddedFileSystem;
        internal readonly PathString requestPath;
        private string dataFile;

        public EmbeddedPathProvider(EmbeddedFileSystem embeddedFileSystem, PathString requestPath)
            : base()
        {
            this.embeddedFileSystem = embeddedFileSystem;
            this.requestPath = requestPath;
        }

        protected override void Initialize()
        {

        }


        /// <summary> 
        ///   Determines whether a specified virtual path is within 
        ///   the virtual file system. 
        /// </summary> 
        /// <param name="virtualPath">An absolute virtual path.</param>
        /// <returns> 
        ///   true if the virtual path is within the  
        ///   virtual file sytem; otherwise, false. 
        /// </returns> 
        private bool IsPathVirtual(string virtualPath)
        {
            String checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return checkPath.StartsWith("~" + requestPath.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool FileExists(string virtualPath)
        {
            if (IsPathVirtual(virtualPath))
            {
                EmbeddedVirtualFile file = (EmbeddedVirtualFile)GetFile(virtualPath);
                return file.Exists;
            }
            else
                return Previous.FileExists(virtualPath);
        }



        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsPathVirtual(virtualPath))
                return new EmbeddedVirtualFile(virtualPath, this);
            else
                return Previous.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsPathVirtual(virtualPath))
            {
                return null;
            }
            try
            {
                var preResult = Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
                return preResult;
            }catch
            {
                return null;

            }
            
            //return IsPathVirtual(virtualPath) ? null : base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);

        }
        //public override CacheDependency GetCacheDependency(
        //  string virtualPath,
        //  System.Collections.IEnumerable virtualPathDependencies,
        //  DateTime utcStart)
        //{
        //    if (IsPathVirtual(virtualPath))
        //    {
        //        System.Collections.Specialized.StringCollection fullPathDependencies = null;

        //        // Get the full path to all dependencies. 
        //        foreach (string virtualDependency in virtualPathDependencies)
        //        {
        //            if (fullPathDependencies == null)
        //                fullPathDependencies = new System.Collections.Specialized.StringCollection();

        //            fullPathDependencies.Add(virtualDependency);
        //        }
        //        if (fullPathDependencies == null)
        //            return null;

        //        // Copy the list of full-path dependencies into an array. 
        //        string[] fullPathDependenciesArray = new string[fullPathDependencies.Count];
        //        fullPathDependencies.CopyTo(fullPathDependenciesArray, 0);
        //        // Copy the virtual path into an array. 
        //        string[] virtualPathArray = new string[1];
        //        virtualPathArray[0] = virtualPath;

        //        return new CacheDependency(virtualPathArray, fullPathDependenciesArray, utcStart);
        //    }
        //    else
        //        return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        //}
    }

    public class EmbeddedVirtualFile : VirtualFile
    {

        private EmbeddedPathProvider provider;

        public bool Exists
        {
            get
            {
                IFileInfo fileInfo;
                return provider.embeddedFileSystem.TryGetFileInfo(this.VirtualPath.Remove(0,provider.requestPath.Value.Length), out fileInfo);
            }
        }

        public EmbeddedVirtualFile(string virtualPath, EmbeddedPathProvider provider)
            : base(virtualPath)
        {
            this.provider = provider;

        }

        public override Stream Open()
        {
            IFileInfo fileInfo;
            provider.embeddedFileSystem.TryGetFileInfo(this.VirtualPath.Remove(0, provider.requestPath.Value.Length), out fileInfo);
            return fileInfo.CreateReadStream();
        }
    }


}
