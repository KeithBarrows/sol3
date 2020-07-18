using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Sol3.Infrastructure.Security.OIDC.Authorize
{
    public class AuthorizeFilter_MvcTemplate : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
