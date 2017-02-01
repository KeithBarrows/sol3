using System.Web.Http;
using Serilog;

namespace Sol3.Azure.Service.WorkerRole.Process.Feature.Api
{
    [RoutePrefix("api/maker")]
    public class ApiMakerController : ApiController
    {
        private readonly string _iftttUri = @"https://maker.ifttt.com/trigger/{event}/with/key/{secret_key}";
        private readonly string _jsonPayload = @"{ 'value1' : 'hello', 'value2' : 'hello', 'value3' : 'hello'}";
        private readonly string _secretKey = @"bhwlKkq-Nfb3Kb7fhPgUPx";
        private readonly string _contentType = @"application/x-www-form-urlencoded";


        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "GET IS COMPLETE!";
        }

        //[HttpGet]
        [HttpPut]
        [Route("test")]
        public void Test()
        {
            Log.Logger.Information("Received test package...");
        }
    }
}
