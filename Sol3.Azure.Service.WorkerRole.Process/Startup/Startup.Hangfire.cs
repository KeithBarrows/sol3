using Owin;
using Serilog;

namespace Sol3.Azure.Service.WorkerRole.Process.Startup
{
    public partial class Startup
    {
        //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        public void RegisterHangfire(IAppBuilder appBuilder)
        {
            Log.Logger.Debug("[STARTUP] RegisterHangfire({@appBuilder})", appBuilder);

            Log.Logger.Warning("RegisterHangfire Not Implemented!!");

            Log.Logger.Information("[STARTUP] RegisterHangfire Complete");
        }
    }
}
