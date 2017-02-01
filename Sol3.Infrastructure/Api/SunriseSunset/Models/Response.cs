using Newtonsoft.Json;

namespace Sol3.Infrastructure.Api.SunriseSunset.Models
{
    public class Response
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("results")]
        public ModelResults Results { get; set; }
    }
}