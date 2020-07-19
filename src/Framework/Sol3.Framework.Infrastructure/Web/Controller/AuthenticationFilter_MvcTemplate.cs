using Serilog;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Sol3.Framework.Infrastructure.Web.Controller
{
    public class AuthenticationFilter_MvcTemplate : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            Log.Information("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.Principal.Identity);

            if (!filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            Log.Information("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.DisplayMode);
        }
    }
}
