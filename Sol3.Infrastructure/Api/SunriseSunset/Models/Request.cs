using System;
using System.Collections.Generic;
using Sol3.Infrastructure.Extensions;

namespace Sol3.Infrastructure.Api.SunriseSunset.Models
{
    public class Request
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? Date { get; set; }
        public bool? Formatted { get; set; }

        public string Uri => $"http://api.sunrise-sunset.org/json?";
        public Dictionary<string, string> Values => GetDictionary();


        private Dictionary<string, string> GetDictionary()
        {
            var values = new Dictionary<string, string>
            {
                {"lat", $"{Latitude:#0.0000000}"},
                {"lng", $"{Longitude:#0.0000000}"}
            };
            if(Date.HasValue) values.Add("date", $"{Date:yyyy-MM-dd}");
            if(Formatted.HasValue) values.Add("formatted", $"{Formatted.ToInt()}");

            return values;
        }
    }
}
