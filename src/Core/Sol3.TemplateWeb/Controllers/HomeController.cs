using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Serilog;
using Sol3.TemplateWeb.Models;

namespace Sol3.TemplateWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    //public class AuthorizeFilter_MvcTemplate : AuthorizeAttribute
    //{
    //    private readonly string[] _allowedRoles;
    //    public AuthorizeFilter_MvcTemplate(params string[] roles)
    //    {
    //        _allowedRoles = roles;
    //    }

    //    //protected override bool AuthorizeCore(Web.HttpContextBase httpContext)
    //    //{
    //    //    bool authorize = false;
    //    //    var userId = Convert.ToString(httpContext.Session["UserId"]);
    //    //    if (!string.IsNullOrEmpty(userId))
    //    //        using (var context = new SqlDbContext())
    //    //        {
    //    //            var userRole = (from u in context.Users
    //    //                            join r in context.Roles on u.RoleId equals r.Id
    //    //                            where u.UserId == userId
    //    //                            select new
    //    //                            {
    //    //                                r.Name
    //    //                            }).FirstOrDefault();
    //    //            foreach (var role in allowedroles)
    //    //            {
    //    //                if (role == userRole.Name) return true;
    //    //            }
    //    //        }
    //    //    return authorize;
    //    //}

    //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        filterContext.Result = new RedirectToRouteResult(
    //           new RouteValueDictionary
    //           {
    //                { "controller", "Home" },
    //                { "action", "UnAuthorized" }
    //           });
    //    }

    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        Log.Information("", filterContext.Controller, filterContext.ActionDescriptor, filterContext.Result);
    //    }
    //}
}
