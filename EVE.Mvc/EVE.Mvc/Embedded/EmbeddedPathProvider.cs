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
    /// <summary>
    /// Implementaion of VirtualPath provider that redirects the path requests to Embedded File System.
    /// Thus you can store razor views for example embedded in an EFS.
    /// You also need to provide this if you are using resources that are bundled (scripts or styles)
    /// </summary>
    public class EmbeddedPathProvider : VirtualPathProvider
    {

        internal readonly EmbeddedFileSystem embeddedFileSystem;
        internal readonly PathString requestPath;
        /// <summary>
        /// Constructor, defines EmbeddedPathProvider by EFS and base requestPath on which EFS is registered
        /// </summary>
        /// <param name="embeddedFileSystem">Underlying Embedded FIle System</param>
        /// <param name="requestPath">requestPath on which EFS is registered</param>
        public EmbeddedPathProvider(EmbeddedFileSystem embeddedFileSystem, PathString requestPath)
            : base()
        {
            this.embeddedFileSystem = embeddedFileSystem;
            this.requestPath = requestPath;
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
            // we consider this a valid path under the jurisdiction of this virtualpath provider if the 
            // URL starts with the given requestPath. Then we'll try to resolve the URL here
            return checkPath.StartsWith("~" + requestPath.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines that the file exists in EFS
        /// </summary>
        /// <param name="virtualPath">URL for the file</param>
        /// <returns>True if the file exists in EFS, false otherwise.</returns>
        public override bool FileExists(string virtualPath)
        {
            if (IsPathVirtual(virtualPath))
            {
                //EmbeddedVirtualFile is a wrapper on the actual file, so we can safely try to retrieve it.
                //actual file content lazy loaded 
                EmbeddedVirtualFile file = (EmbeddedVirtualFile)GetFile(virtualPath);
                return file.Exists;
            }
            else
                return Previous.FileExists(virtualPath);
        }


        /// <summary>
        /// Gets the EmbeddedVirtualFile for the given URL
        /// </summary>
        /// <param name="virtualPath">URL for the file</param>
        /// <returns>EmbeddedVirtualFile for the given URL</returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsPathVirtual(virtualPath))
                return new EmbeddedVirtualFile(virtualPath, this);
            else
                return Previous.GetFile(virtualPath);
        }

        /// <summary>
        /// Provides physical file cache dependency related to the given url.
        /// </summary>
        /// <param name="virtualPath">The path to the primary virtual resource.</param>
        /// <param name="virtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
        /// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
        /// <returns></returns>
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsPathVirtual(virtualPath))
            {
                //the dependency will be the assembly that the EFS is based on
                return new CacheDependency(embeddedFileSystem.AssemblyPath, utcStart);
               
            }

            //TODO: For some reason on bundle virtualPath's we're getting an exception here,
            // need to investigate more and remove this ugly hack
            try
            {
                var preResult = Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
                return preResult;
            }catch
            {
                return null;

            }

        }

    }
    /// <summary>
    /// Wrapper class around the EFS file instance for the virtual path provider
    /// </summary>
    public class EmbeddedVirtualFile : VirtualFile
    {

        private EmbeddedPathProvider provider;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="virtualPath">virtual path</param>
        /// <param name="provider">calling virtual path provider</param>
        public EmbeddedVirtualFile(string virtualPath, EmbeddedPathProvider provider)
            : base(virtualPath)
        {
            if (provider == null)
                throw new ArgumentNullException("provider", "Provider cannot be null");
            this.provider = provider;

        }
        /// <summary>
        /// Checks if a file exists. True if it exists, false otherwise.
        /// </summary>
        public bool Exists
        {
            get
            {
                IFileInfo fileInfo;
                //creating local reqPath here because provider is marshalByRef
                var reqPath = provider.requestPath;
                if (reqPath == null)
                    throw new ArgumentException("Provider's requestPath must exist", "provider.requestPath");

                return provider.embeddedFileSystem.TryGetFileInfo(this.VirtualPath.Remove(0, provider.requestPath.Value.Length), out fileInfo);
            }
        }
        /// <summary>
        /// Returns the stream of the file's content
        /// </summary>
        /// <returns> stream of the file's content</returns>
        public override Stream Open()
        {
            IFileInfo fileInfo;
            //creating local reqPath here because provider is marshalByRef
            var reqPath = provider.requestPath;
            if (reqPath == null)
                throw new ArgumentException("Provider's requestPath must exist", "provider.requestPath");

            provider.embeddedFileSystem.TryGetFileInfo(this.VirtualPath.Remove(0, reqPath.Value.Length), out fileInfo);
            return fileInfo.CreateReadStream();
        }
    }


}
