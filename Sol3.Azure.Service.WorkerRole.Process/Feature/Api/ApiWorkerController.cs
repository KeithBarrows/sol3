using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Serilog;
using Sol3.Infrastructure.Extensions;

namespace Sol3.Azure.Service.WorkerRole.Process.Feature.Api
{
    [RoutePrefix("api/worker")]
    public class ApiWorkerController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "GET IS COMPLETE!";
        }

        [HttpGet]
        [HttpPut]
        [Route("Shutdown/{id:int}")]
        public void Shutdown(int id)
        {
            Log.Logger.Information("Shutdown requested via API while in DEBUG mode...");
            if (!AppSettings.Instance.IsService)
                AppSettings.Instance.CancellationTokenSource.Cancel();
        }
    }
}
