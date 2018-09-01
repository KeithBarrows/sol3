using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sol3.Infrastructure.Base.Configuration;
using Sol3.Infrastructure.IoT.Weather.Models;

namespace Sol3.TestCli
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        private static IServiceCollection _services;
        private static IServiceProvider _provider;

        static void Main(string[] args)
        {
            _configuration = ConfigurationManager.InitializeConfiguration<Program>();

            _services = new ServiceCollection();
            _services.AddSingleton<IConfigurationRoot>(_configuration);
            _provider = _services.BuildServiceProvider();

            var locations = new List<Location>();
            _configuration.Bind("Locations", locations);

            Console.WriteLine("Hello World!");

            var darkSky = new Infrastructure.IoT.Weather.DarkSky(_provider);

            var location = locations.FirstOrDefault(a => a.Name.Contains("Frederick"));
            var result = darkSky.GetToday(location);

            var results = darkSky.GetHistoryComparison(1, 2018);
            var days = results.Count / 2;

            for (int day = 1; day <= days; day++)
            {
                var home = results[$"Day {day:00} in {locations[0]}"];
                var florida = results[$"Day {day:00} in Ft Lauderdale, FL"];

                for (int hour = 0; hour < 24; hour++)
                {
                    var p1 = home.Hourly.Data[hour];
                    var p2 = florida.Hourly.Data[hour];
                    Console.WriteLine($"{p1.DateTime}|{p1.ApparentTemperature}|{p1.Pressure}|{p2.ApparentTemperature}|{p2.Pressure}");
                }
            }



            //foreach (var result in results)
            //{
            //    Console.WriteLine($"{result.Value.Currently.DateTime} == {result.Currently.SunriseDateTime} == {result.Currently.SunsetDateTime}");
            //    result.Hourly.Data.ForEach(hourly => Console.WriteLine($" +-- {hourly.DateTime} == {hourly.ApparentTemperature} == {hourly.Pressure}"));
            //}

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
