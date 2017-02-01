using System;
using Newtonsoft.Json;
using Sol3.Infrastructure.Api.SunriseSunset.Models;
using Sol3.Infrastructure.Extensions;

namespace Sol3.Infrastructure.Api.SunriseSunset
{
    /// <summary>
    /// http://sunrise-sunset.org/api
    /// </summary>
    public class Handler
    {
        private Response Response { get; set; }
        public string Status => Response.Status;
        public ModelResults ResultsRawUtc => Response.Results;
        public ModelLocalResults ResultsLocal { get; private set; }


        public void ExecuteRequest(double latitude, double longitude)
        {
            var request = new Request { Latitude = latitude, Longitude = longitude };
            Execute(request, DateTime.Today);
        }
        public void ExecuteRequest(double latitude, double longitude, DateTime date)
        {
            var request = new Request { Latitude = latitude, Longitude = longitude, Date = date };
            Execute(request, date);
        }
        public void ExecuteRequest(double latitude, double longitude, bool formatted)
        {
            var request = new Request { Latitude = latitude, Longitude = longitude, Formatted = formatted };
            Execute(request, DateTime.Today);
        }
        public void ExecuteRequest(double latitude, double longitude, DateTime date, bool formatted)
        {
            var request = new Request { Latitude = latitude, Longitude = longitude, Date = date, Formatted = formatted };
            Execute(request, date);
        }

        private void Execute(Request request, DateTime date)
        {
            var response = request.Values.ExecuteHttpRequest(request.Uri);
            var responseObject = JsonConvert.DeserializeObject<Response>(response);
            Response = responseObject;
            ResultsLocal = new ModelLocalResults(Response.Results, date);
        }
    }
}
