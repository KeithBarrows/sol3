using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Sol3.Infrastructure.Security.OIDC.Authenticate
{
    public class AuthenticationFilter_MvcTemplate : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            Debug.WriteLine("OnAuthentication");

            if (!filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            Debug.WriteLine("OnAuthenticationChallenge");
        }
    }
}
