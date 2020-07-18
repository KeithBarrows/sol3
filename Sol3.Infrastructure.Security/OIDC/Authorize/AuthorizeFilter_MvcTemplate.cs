using System.Diagnostics;
using System.Web.Mvc;

namespace Sol3.Infrastructure.Security.OIDC.Authorize
{
    public class AuthorizeFilter_MvcTemplate : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("OnAuthorization");
        }
    }
}
