using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using RazorEngine.Templating;
using RazorEngine;

namespace Bookly.Mvc
{
    public class EmbeddedStringResult : IHttpActionResult
    {
        string path;
        string file;
       

        public EmbeddedStringResult(HttpRequestMessage request, string file)
        {
            var pathbase = request.GetOwinContext().Request.PathBase;
            this.path = pathbase.Value;
            this.file = file;
       
        }

        public Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(GetResponseMessage());
        }

        public HttpResponseMessage GetResponseMessage()
        {
            
            var html = AssetManager.LoadResourceString(this.file,typeof(EmbeddedStringResult).Assembly.FullName);
               

            return new HttpResponseMessage()
            {
                Content = new StringContent(html, System.Text.Encoding.UTF8, "text/html")
            };
        }

        
    }
}
