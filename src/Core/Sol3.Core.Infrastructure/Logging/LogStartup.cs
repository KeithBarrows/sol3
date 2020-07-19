using Serilog;
using Serilog.Events;

namespace Sol3.Infrastructure.Logging
{
    public static class LogStartup
    {
        public static ILogger CreateSerilogLogger()
        {
            /*
             * https://nblumhardt.com/2019/10/serilog-mvc-logging/
             * https://andrewlock.net/series/using-serilog-aspnetcore-in-asp-net-core-3/
             */
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

            return Log.Logger;
        }
    }
}
