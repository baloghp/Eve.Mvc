using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using RazorEngine.Templating;
using RazorEngine;
using System.Reflection;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EVE.Mvc
{
    public class EmbeddedHtmlStringResult : ContentResult
    {
       
        string file;
        Assembly assembly;
       

        public EmbeddedHtmlStringResult( string file, string assemblyName)
        {
            
            this.file = file;
            this.assembly = (from a in AppDomain.CurrentDomain.GetAssemblies()
                                where a.FullName == assemblyName
                                select a).FirstOrDefault();
        }

        public EmbeddedHtmlStringResult( string file, Assembly assembly)
        {
          
            this.file = file;
            this.assembly = assembly;
        }

        public string GetResponseMessage()
        {
            
            return AssetManager.LoadResourceString(this.file,assembly);
            
        }



        public override void ExecuteResult(ControllerContext context)
        {
            ContentResult c = new ContentResult();
            c.Content = GetResponseMessage();
            c.ContentType = "text/html";
            c.ContentEncoding = System.Text.Encoding.UTF8;
            c.ExecuteResult(context);
        }
    }
}
