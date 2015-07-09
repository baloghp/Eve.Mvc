using EVE.Mvc.Composition;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EVE.Mvc
{

    public class EmbeddedViewEngine : IViewEngine
    {
        public IEnumerable<EmbeddedResourceOption> options;
        public Dictionary<string, Lazy<EmbeddedView>> allViews;
       

        public EmbeddedViewEngine():this(new List<EmbeddedResourceOption>() { 
                new EmbeddedResourceOption()
                {
                    Extension = ".html"
                },
                new EmbeddedResourceOption()
                {
                    Extension = ".cshtml"
                }
            })
        {
           
        }

        public EmbeddedViewEngine(IEnumerable<EmbeddedResourceOption> options)
        {

            this.options = options;
            InitializeAllViews();
        }

        private void InitializeAllViews()
        {
            
        }
        
      

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            EmbeddedView view = GetView(partialViewName);
            if (view != null)
            {
                view.ViewName = partialViewName;
                return new ViewEngineResult(view, this);
            }
            return new ViewEngineResult(new string[] { partialViewName });
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            EmbeddedView view = GetView(viewName);
            if (view != null )
            {
                view.ViewName = viewName;
                view.MasterName = masterName;

                return new ViewEngineResult(view, this);
            }
            return new ViewEngineResult(new string[] { masterName, viewName });
        }

        private EmbeddedView GetView(string viewName)
        {
            var views = EveMefContainer.Container.GetExports<EmbeddedView>(viewName);
            if (views != null && views.Count() > 0)
            {
                var view = views.First().Value;
                return view;
            }
            else
            {
                AssetManager.LoadResourceString(viewName);

            }
            return null;
        }

       

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }
    }

    public class EmbeddedResourceOption
    {
        public string Extension { get; set; }

    }
}
