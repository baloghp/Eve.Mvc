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
    public class EmbeddedHtmlStringResult : ContentResult, IHttpActionResult
    {

        string file;
        Assembly assembly;


        public EmbeddedHtmlStringResult(string file, string assemblyName)
        {

            this.file = file;
            this.assembly = (from a in AppDomain.CurrentDomain.GetAssemblies()
                             where a.FullName == assemblyName
                             select a).FirstOrDefault();
        }

        public EmbeddedHtmlStringResult(string file, Assembly assembly)
        {

            this.file = file;
            this.assembly = assembly;
        }

        public string GetResponseString()
        {

            return AssetManager.LoadResourceString(this.file, assembly);

        }



        public override void ExecuteResult(ControllerContext context)
        {
            ContentResult c = new ContentResult();
            c.Content = GetResponseString();
            c.ContentType = "text/html";
            c.ContentEncoding = System.Text.Encoding.UTF8;
            c.ExecuteResult(context);
        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(GetResponseMessage());
        }

        public HttpResponseMessage GetResponseMessage()
        {

            var html = AssetManager.LoadResourceString(this.file, assembly);


            return new HttpResponseMessage()
            {
                Content = new StringContent(html, System.Text.Encoding.UTF8, "text/html")
            };
        }

    }
}
