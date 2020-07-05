using System;
using System.Linq;
using System.Web.Mvc;
using Castle.DynamicProxy;
using Glass.Mapper.Sc.Web.Mvc;
using Common.Foundation.Glass.Models.Core;
using Common.Foundation.Utilities.Core;

namespace Common.Foundation.Glass.Models.Mvc
{
    /// <summary>
    /// Shortcut class name to make a glass view editable
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [Obsolete("Use GlassView instead. Views/Web.config should contain <add namespace=\"Glass.Mapper.Sc.Web.Mvc\" />", true)]
    public abstract class MakeEditable<TModel> : GlassView<TModel> where TModel : class
    {
    }
    
    /// <summary>
    /// Extensions to provide feedback to content authors when attempting to set datasource on rendering that does not agree with view.
    /// </summary>
    public static class CoreMvcExtensions
    {
        private const String ErrMsgKey = "CoreExt_ModelErr";

        public static Boolean IsType(this CoreInferred model, params Type[] types)
        {
            var isValid = false;

            // Get Type from regular objects and Castle Proxy Objects
            var modelType = ProxyUtil.GetUnproxiedType(model);

            foreach( var type in types )
            {
                if ( type.IsAssignableFrom(modelType) )
                {
                    isValid = true;
                    break;
                }
            }

            if( !isValid )
                Request.Items.Set<String>(
                    ErrMsgKey,
                    String.Format(
                        "This rendering requires type {0}. (attempted type {1})", 
                        String.Join(", ",types.Select(t=>t.Name).ToList()),
                        model.GetType().ToString()
                    )
                );
            
            
            return isValid;
        }

        public static Boolean IsType(this Sitecore.Mvc.Presentation.RenderingModel model, params Type[] types)
        {
            var isValid = false;

            // Get Type from regular objects and Castle Proxy Objects
            var modelType = ProxyUtil.GetUnproxiedType(model);

            foreach (var type in types)
            {
                if (type.IsAssignableFrom(modelType))
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
                Request.Items.Set<String>(
                    ErrMsgKey,
                    String.Format(
                        "This rendering requires type {0}. (attempted type {1})",
                        String.Join(", ", types.Select(t => t.Name).ToList()),
                        model.GetType().ToString()
                    )
                );


            return isValid;
        }

        /// <summary>
        /// Retrieve error message when invalid
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString IsTypeInvalidMessage(this HtmlHelper htmlHelper)
        {
            var msg = Request.Items.Get<String>(ErrMsgKey) ?? String.Empty;

            return new MvcHtmlString(msg);
        }
    }
}
