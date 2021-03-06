﻿using Serilog;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sol3.Framework.Infrastructure.Web.Controller
{
    public class AuthorizeFilter_MvcTemplate : AuthorizeAttribute
    {
        private readonly string[] _allowedRoles;
        public AuthorizeFilter_MvcTemplate(params string[] roles)
        {
            _allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            //if (!string.IsNullOrEmpty(userId))
            //    using (var context = new SqlDbContext())
            //    {
            //        var userRole = (from u in context.Users
            //                        join r in context.Roles on u.RoleId equals r.Id
            //                        where u.UserId == userId
            //                        select new
            //                        {
            //                            r.Name
            //                        }).FirstOrDefault();
            //        foreach (var role in allowedroles)
            //        {
            //            if (role == userRole.Name) return true;
            //        }
            //    }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Log.Debug("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.Result);
        }
    }
}
