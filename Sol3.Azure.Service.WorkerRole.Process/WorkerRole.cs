using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Owin.Hosting;
using Serilog;
using Sol3.Azure.Service.WorkerRole.Process.Startup;


namespace Sol3.Azure.Service.WorkerRole.Process
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app = null;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _safeToExitHandle = new ManualResetEvent(false);

        public override void Run()
        {
            Log.Logger.Debug("[WorkerRole] Run");
            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process is running");

            try
            {
                this.RunAsync(this._cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this._safeToExitHandle.Set();
            }
            Log.Logger.Information("[WorkerRole] Run Complete");
        }

        public override bool OnStart()
        {
            Initialize();

            AppSettings.Instance.CancellationTokenSource = _cancellationTokenSource;

            Log.Logger.Debug("[WorkerRole] OnStart");

            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            // New code:
            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Endpoint1"];
            string baseUri = $"{endpoint.Protocol}://{endpoint.IPEndpoint}";

            baseUri = baseUri.Replace("127.0.0.1", "capricus.sol3.net");
            Log.Logger.Debug("[WorkerRole] Endpoint {@baseUri}", baseUri);

            Trace.TraceInformation($"Starting OWIN at {baseUri}", "Information");

            _app = WebApp.Start<Startup.Startup>(new StartOptions(url: baseUri));

            var result = base.OnStart();

            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process has been started");

            Log.Logger.Information("[WorkerRole] OnStart Complete");
            return result;
        }

        public override void OnStop()
        {
            Log.Logger.Debug("[WorkerRole] OnStop");
            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process is stopping");

            this._cancellationTokenSource.Cancel();
            if (AppSettings.Instance.IsService)
                this._safeToExitHandle.WaitOne();

            _app?.Dispose();

            base.OnStop();

            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process has stopped");
            Log.Logger.Information("[WorkerRole] OnStop Complete");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            Log.Logger.Debug("[WorkerRole] RunAsync");

            // TODO: Replace the following with your own logic.

            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                //await Task.Delay(1000);
                AppSettings.Instance.CancellationToken.WaitHandle.WaitOne(10000);
            }

            Log.Logger.Information("[WorkerRole] RunAsync Complete");

            if (!AppSettings.Instance.IsService)
                OnStop();
        }


        internal static void Initialize()
        {
            // Put this at the very beginning so that IoC and Logging are loaded and ready for use...
            var programStartup = new ProgramStartup();
            programStartup.InitializeLogging();
            programStartup.InitializeIoC();

            Log.Logger.Debug("[WorkerRole] Initialize - Logging and IoC");
            Log.Logger.Information("[WorkerRole] Initialize Complete");
        }
    }
}
