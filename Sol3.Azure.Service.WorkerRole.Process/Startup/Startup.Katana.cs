using System.Web.Http;
using Microsoft.Owin.Diagnostics;
using Owin;
using Serilog;

namespace Sol3.Azure.Service.WorkerRole.Process.Startup
{
    public partial class Startup
    {
        //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        public void RegisterKatana(IAppBuilder appBuilder)
        {
            Log.Logger.Debug("[STARTUP] RegisterKatana({@appBuilder})", appBuilder);
            Log.Logger.Debug("Enable attribute based routing.");

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Feature/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnsureInitialized();
            appBuilder.UseWebApi(config);

            appBuilder.UseWelcomePage("/");
            appBuilder.UseErrorPage(ErrorPageOptions.ShowAll);


            Log.Logger.Information("[STARTUP] RegisterKatana Complete");
        }
    }
}
