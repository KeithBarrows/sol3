using Hangfire;
using Owin;
using Serilog;
using Sol3.Infrastructure.Filters;

namespace Sol3.Azure.Service.WorkerRole.Process.Startup
{
    public partial class Startup
    {
        //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        public void RegisterHangfire(IAppBuilder appBuilder)
        {
            Log.Logger.Debug("[STARTUP] RegisterHangfire({@appBuilder})", appBuilder);
            Log.Logger.Warning("RegisterHangfire Not Implemented!!");

            GlobalConfiguration.Configuration.UseSqlServerStorage(AppSettings.Instance.HangfireConnectionString);
            GlobalConfiguration.Configuration.UseFilter(new JobContext());
            GlobalJobFilters.Filters.Add(new LogAttribute());
            appBuilder.UseHangfireDashboard();
            var options = new BackgroundJobServerOptions
            {
                Queues = AppSettings.Instance.QueueNames,
                //Activator = new UnityJobActivator(AppSettings.Instance.UnityContainer),
            };
            appBuilder.UseHangfireServer(options);


            Log.Logger.Information("[STARTUP] RegisterHangfire Complete");
        }
    }
}
