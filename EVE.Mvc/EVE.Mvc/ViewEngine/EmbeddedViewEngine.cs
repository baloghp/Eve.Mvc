using EVE.Mvc.Composition;
using EVE.Mvc.ViewEngine;
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

    /// <summary>
    /// View engine implementation. This class is responsible to find markup and code parts of the views, and provide appropriate fall-backs should one be missing.
    /// </summary>
    public class EmbeddedViewEngine : IViewEngine
    {

        /// <summary>
        /// Gets or sets the view name prefix, of the view engine
        /// </summary>
        /// <value>
        /// The view name prefix.
        /// </value>
        public string ViewNamePrefix { get; set; }

        /// <summary>
        /// Gets the markup provider, of the view engine
        /// </summary>
        /// <value>
        /// The markup provider.
        /// </value>
        public BaseMarkupProvider MarkupProvider { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedViewEngine"/> class.
        /// </summary>
        public EmbeddedViewEngine()
            : this(string.Empty, EVE.Mvc.ViewEngine.MarkupProvider.CurrentProvider)
        {
           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedViewEngine"/> class.
        /// </summary>
        /// <param name="viewNamePrefix">The view name prefix.</param>
        public EmbeddedViewEngine(string viewNamePrefix)
            : this(viewNamePrefix, EVE.Mvc.ViewEngine.MarkupProvider.CurrentProvider)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedViewEngine"/> class.
        /// </summary>
        /// <param name="viewNamePrefix">The view name prefix.</param>
        /// <param name="markupProvider">The markup provider.</param>
        public EmbeddedViewEngine(string viewNamePrefix, BaseMarkupProvider markupProvider)
        {
            ViewNamePrefix = viewNamePrefix;
            this.MarkupProvider = markupProvider;
        }

        /// <summary>
        /// Finds the specified partial view by using the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="partialViewName">The name of the partial view.</param>
        /// <param name="useCache">true to specify that the view engine returns the cached view, if a cached view exists; otherwise, false.</param>
        /// <returns>
        /// The partial view.
        /// </returns>
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            IEmbeddedView view = GetView(partialViewName);
            if (view != null)
            {
                view.ViewName = partialViewName;
                return new ViewEngineResult(view, this);
            }
            return new ViewEngineResult(new string[] { partialViewName });
        }

        /// <summary>
        /// Finds the specified view by using the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewName">The name of the view.</param>
        /// <param name="masterName">The name of the master.</param>
        /// <param name="useCache">true to specify that the view engine returns the cached view, if a cached view exists; otherwise, false.</param>
        /// <returns>
        /// The page view.
        /// </returns>
        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            IEmbeddedView view = GetView(viewName);
            if (view != null )
            {
                view.ViewName = viewName;
                //set master name only if there is one specified,
                //otherwise let the view try to figure out by its attributes
                if (!string.IsNullOrWhiteSpace(masterName))
                {
                    view.MasterName = masterName;
                }

                return new ViewEngineResult(view, this);
            }
            return new ViewEngineResult(new string[] { masterName, viewName });
        }
        /// <summary>
        /// So! A typical view is made up of an EmbeddedView class and a pice of markup string.
        /// First we look for the class and then pass the markup to it. 
        /// We're going to assume that if a class exists the corresponding markup will be in proximity to it (same assembly).
        /// So we're going to pass both the view name and the view class to the markup provider. 
        /// The default markup provider will look for the markup as an embedded string in the view class's assembly.
        /// If we do not find a class we still look for a markup using the same provider 
        /// (so the providers must be prepared to handle the scenario  when now view class is passed)
        /// and pass it to a "empty" embedded view.
        /// If we find a class but no markup we just pass the class on.
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private IEmbeddedView GetView(string viewName)
        {
            string realViewName = UnprefixViewName(viewName);
            if (string.IsNullOrWhiteSpace(realViewName)) return null;
            IEmbeddedView view = FindEmbeddedViewClass(viewName);
            string markup = FindMarkup(realViewName, view);
            if (view != null)
            {
                if (!(string.IsNullOrEmpty(markup)))
                {
                    view.RawMarkup = markup;
                }
                return view;
            }
            if (!(string.IsNullOrEmpty(markup)))
            {
                var sview = new SimpleResourceView();
                sview.RawMarkup = markup;
                return sview;
            }

            return null;
        }

        private string UnprefixViewName(string viewName)
        {
            if (!String.IsNullOrWhiteSpace(this.ViewNamePrefix))
            {
                if (viewName.StartsWith(this.ViewNamePrefix))
                {
                    return viewName.Remove(0, this.ViewNamePrefix.Length);
                }else
                    return string.Empty;
            }
            return viewName;
        }

        private string FindMarkup(string viewName, IEmbeddedView view)
        {
            
            if (view!=null)
            {
                //let's see if there is a markup name specified for the view class
                var viewAttribute = view.GetType().GetCustomAttribute<EmbeddedViewAttribute>();
                if (viewAttribute != null && !String.IsNullOrWhiteSpace(viewAttribute.MarkupName))
                {
                    string result = MarkupProvider.GetResource(viewAttribute.MarkupName, view);
                    if (!String.IsNullOrWhiteSpace(result)) return result;
                }
            }
            

            return MarkupProvider.GetResource(viewName, view);
        }

        private IEmbeddedView FindEmbeddedViewClass(string viewName)
        {
            var views = EveMefContainer.Container.GetExports<IEmbeddedView>(viewName);
            if (views != null && views.Count() > 0)
            {
                var view = views.First().Value;
                return view;
            }
            return null;
        }



        /// <summary>
        /// Releases the specified view by using the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="view">The view.</param>
        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            var embeddedView = view as IEmbeddedView;
            if (view !=null)
            {
               embeddedView.CleanUp();
            }
            //not too sure if we need this!
            //GC.Collect();
        }
    }

    
}
