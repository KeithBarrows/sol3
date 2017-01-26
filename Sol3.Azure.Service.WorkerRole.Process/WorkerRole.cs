using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Owin.Hosting;


namespace Sol3.Azure.Service.WorkerRole.Process
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app = null;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process is running");

            try
            {
                this.RunAsync(this._cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this._runCompleteEvent.Set();

            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            // New code:
            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Endpoint1"];
            string baseUri = $"{endpoint.Protocol}://{endpoint.IPEndpoint}";

            baseUri = baseUri.Replace("127.0.0.1", "capricus.sol3.net");

            Trace.TraceInformation($"Starting OWIN at {baseUri}", "Information");

            _app = WebApp.Start<Startup.Startup>(new StartOptions(url: baseUri));

            bool result = base.OnStart();

            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process is stopping");

            this._cancellationTokenSource.Cancel();
            this._runCompleteEvent.WaitOne();

            _app?.Dispose();

            base.OnStop();

            Trace.TraceInformation("Sol3.Azure.Service.WorkerRole.Process has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
