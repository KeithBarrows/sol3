using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Serilog.Events;
using Sol3.Infrastructure.Hangfire;
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

        public string HangfireConnectionString => $"";
        public Dictionary<int, string> Queues => new Dictionary<int, string> { { 0, "Critical"}, { 1, "Serial" }, { 2, "JobQueue" }, { 3, "AdHoc" }, { 4, "Default" } };  //JsonConvert.DeserializeObject<Dictionary<int, string>>(_camSettings.Queues.Value);
        public string[] QueueNames => Queues.Select(kvp => kvp.Value).ToArray();
        public string QueueName(ChannelName name) { return Queues[(int)name]; }

        public bool DoShutdown { get; set; } = false;
        public bool IsService { get; set; } = false;
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public CancellationToken CancellationToken => CancellationTokenSource.Token;
    }
}
