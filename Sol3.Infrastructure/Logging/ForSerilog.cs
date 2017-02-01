using System.IO;
using Serilog;
using Serilog.Events;
using SerilogWeb.Classic.Enrichers;

namespace Sol3.Infrastructure.Logging
{
    public class ForSerilog
    {
        public void Initialize(string logFilePath, string seqUrl, LogEventLevel seqEventLevelValue, LogEventLevel logFileEventLevelValue, LogEventLevel errorLogFileEventLevelValue)
        {
            var logFile = Path.Combine(logFilePath ?? @"c:\logs\QueueApp\", "Log.log");
            var errorLogFile = Path.Combine(logFilePath ?? @"c:\logs\QueueApp\", "ErrorLog.log");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq(seqUrl ?? "http://localhost:5341", seqEventLevelValue)
                .WriteTo.RollingFile(logFile, logFileEventLevelValue)
                .WriteTo.RollingFile(errorLogFile, errorLogFileEventLevelValue)
                .MinimumLevel.Verbose()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<HttpRequestNumberEnricher>()
                .Enrich.With<HttpSessionIdEnricher>()
                .Enrich.With<UserNameEnricher>()
                .CreateLogger();
        }
    }
}
