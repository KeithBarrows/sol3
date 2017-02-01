using System;

namespace Sol3.Infrastructure.Api.SunriseSunset.Models
{
    public class ModelLocalResults
    {
        private readonly ModelResults _results;
        private readonly DateTime _targetDay;

        public ModelLocalResults(ModelResults results, DateTime targetDay)
        {
            _results = results;
            _targetDay = targetDay;
        }

        public DateTime Sunrise => GetLocalTime(_results.Sunrise);
        public DateTime Sunset => GetLocalTime(_results.Sunset);
        public DateTime AstronomicalTwilightBegin => GetLocalTime(_results.AstronomicalTwilightBegin);
        public DateTime AstronomicalTwilightEnd => GetLocalTime(_results.AstronomicalTwilightEnd);
        public DateTime CivilTwilightBegin => GetLocalTime(_results.CivilTwilightBegin);
        public DateTime CivilTwilightEnd => GetLocalTime(_results.CivilTwilightEnd);
        public DateTime DayLength => GetLocalTime(_results.DayLength);
        public DateTime NauticalTwilightBegin => GetLocalTime(_results.NauticalTwilightBegin);
        public DateTime NauticalTwilightEnd => GetLocalTime(_results.NauticalTwilightEnd);
        public DateTime SolarNoon => GetLocalTime(_results.SolarNoon);


        private DateTime GetLocalTime(string time)
        {
            var tm = Convert.ToDateTime(time);
            var dt = new DateTime(_targetDay.Year, _targetDay.Month, _targetDay.Day, tm.Hour, tm.Minute, tm.Second, DateTimeKind.Utc);
            return dt.ToLocalTime();
        }

    }
}
