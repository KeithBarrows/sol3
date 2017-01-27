using System;
using System.Threading;
using Serilog.Events;
using Sol3.Infrastructure.Patterns.Creational;

namespace Sol3.Azure.Service.WorkerRole.Process
{
    public class AppSettings : Singleton<AppSettings>
    {
        public string LogFile => $"{Environment.CurrentDirectory}\\logs\\Log.log";
        public string ErrorLogFile => $"{Environment.CurrentDirectory}\\logs\\ErrorLog.log";
        public string SeqBuffer => $"{Environment.CurrentDirectory}\\logs\\SeqBuffer\\";
        public LogEventLevel LogFileEventLevelValue => LogEventLevel.Verbose;
        public LogEventLevel ErrorLogFileEventLevelValue => LogEventLevel.Error;
        public LogEventLevel SeqEventLevelValue => LogEventLevel.Verbose;
        public string SeqUrl => "http://capricus.sol3.net:5341";

        public bool DoShutdown { get; set; } = false;
        public bool IsService { get; set; } = false;
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public CancellationToken CancellationToken => CancellationTokenSource.Token;
    }
}
