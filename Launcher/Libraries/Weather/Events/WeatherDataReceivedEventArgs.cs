namespace TWC.Weather.Events
{
    using System.Collections.Generic;
    using TWC.Weather.Models;

    public class WeatherDataReceivedEventArgs
    {
        Observation obs;
        List<ForecastDay> days;

        public Observation Observation
        {
            get { return obs; }
        }
        public List<ForecastDay> Forecast
        {
            get { return days; }
        }

        public static WeatherDataReceivedEventArgs Report(Observation observation, List<ForecastDay> forecast)
        {
            return new WeatherDataReceivedEventArgs() { obs = observation, days = forecast };
        }
    }
}
