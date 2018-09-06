using System;
using System.Collections.Generic;
using DarkSky.Models;
using DarkSky.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sol3.Infrastructure.Extensions;
using Sol3.Infrastructure.IoT.Weather.Models;

namespace Sol3.Infrastructure.IoT.Weather
{
    public class DarkSky
    {
        private readonly List<Location> _locations;
        private readonly DarkSkyService _darkSkyService;

        public DarkSky(IServiceProvider provider)
        {
            var config = provider.GetService<IConfigurationRoot>();
            var apiKey = config["DarkSkyApiKey"];
            _darkSkyService = new DarkSkyService(apiKey);

            _locations = new List<Location>();
            config.Bind("Locations", _locations);
        }

        public SunriseSunset GetSunriseSunset(Location location, DateTime dateTime)
        {
            var forecast = _darkSkyService.GetForecast(location.Latitude, location.Longitude, new DarkSkyService.OptionalParameters
            {
                ForecastDateTime = dateTime,
            });
            return new SunriseSunset {
                Sunrise = forecast.Result.Response.Daily.Data[0].SunriseDateTime.ToDateTimeOffset(),
                Sunset = forecast.Result.Response.Daily.Data[0].SunsetDateTime.ToDateTimeOffset()
            };
            
        }
        public Forecast GetToday(Location location)
        {
            return GetToday(location.Latitude, location.Longitude);
        }
        public Forecast GetToday(double latitude, double longitude)
        {
            var forecast = _darkSkyService.GetForecast(latitude, longitude, new DarkSkyService.OptionalParameters
            {
                ForecastDateTime = DateTime.Now,
            });

            return forecast.Result.Response;
        }

        public IEnumerable<Forecast> GetHistoryForMonth(Location location, int month, int year)
        {
            return GetHistoryForMonth(location.Latitude, location.Longitude, month, year);
        }
        public IEnumerable<Forecast> GetHistoryForMonth(double latitude, double longitude, int month, int year)
        {
            var results = new List<Forecast>();

            var maxDay = DateTime.DaysInMonth(year, month);
            for (var day = 1; day <= maxDay; day++)
            {
                AddForecastFor(latitude, longitude, day, month, year, ref results);
            }

            return results;
        }

        public IDictionary<string, Forecast> GetHistoryComparison(int month, int year)
        {
            var maxDay = DateTime.DaysInMonth(year, month);
            var results = new Dictionary<string, Forecast>();

            foreach (var location in _locations)
            {
                for (var day = 1; day <= maxDay; day++)
                {
                    var forecast = _darkSkyService.GetForecast(location.Latitude, location.Longitude, new DarkSkyService.OptionalParameters
                    {
                        ForecastDateTime = new DateTime(year, month, day, 0, 0, 0),
                    });
                    results.Add($"Day {day:00} in {location.Name}", forecast.Result.Response);
                }
            }

            return results;
        }

        #region Helpers
        private void AddForecastFor(double latitude, double longitude, int day, int month, int year, ref List<Forecast> results)
        {
            var forecast = _darkSkyService.GetForecast(latitude, longitude, new DarkSkyService.OptionalParameters
            {
                ForecastDateTime = new DateTime(year, month, day, 0, 0, 0),
            });
            results.Add(forecast.Result.Response);
        }

        #endregion
    }
}
