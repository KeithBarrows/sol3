using Serilog;
using System.Web.Mvc;

namespace Sol3.Framework.Infrastructure.Web.Controller
{
    public class LoggingActionFilter_MvcTemplate : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Debug("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.ActionParameters);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log.Debug("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.Result);
        }
    }
}
