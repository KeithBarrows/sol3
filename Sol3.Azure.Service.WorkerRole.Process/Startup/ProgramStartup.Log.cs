using System;
using System.IO;
using Serilog;
using SerilogWeb.Classic.Enrichers;

namespace Sol3.Azure.Service.WorkerRole.Process.Startup
{
    public partial class ProgramStartup
    {
        public void InitializeLogging()
        {
            //var logFile = Path.Combine(AppSettings.Instance.LogFile ?? $"{Environment.CurrentDirectory}\\logs\\", "Log.log");
            //var errorLogFile = Path.Combine(AppSettings.Instance.LogFile ?? $"{Environment.CurrentDirectory}\\logs\\", "ErrorLog.log");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq(AppSettings.Instance.SeqUrl, AppSettings.Instance.SeqEventLevelValue)
                .WriteTo.RollingFile(AppSettings.Instance.LogFile, AppSettings.Instance.LogFileEventLevelValue)
                .WriteTo.RollingFile(AppSettings.Instance.ErrorLogFile, AppSettings.Instance.ErrorLogFileEventLevelValue)
                .MinimumLevel.Verbose()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<HttpRequestNumberEnricher>()
                .Enrich.With<HttpSessionIdEnricher>()
                .Enrich.With<UserNameEnricher>()
                .CreateLogger();

            Log.Logger.Information("==================================================================");
            Log.Logger.Information("---[ START LOGGING ]---");
            Log.Logger.Information("==================================================================");
        }
    }
}
