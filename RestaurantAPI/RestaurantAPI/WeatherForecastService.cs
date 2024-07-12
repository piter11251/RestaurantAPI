using System.Linq;
using System;
using System.Collections.Generic;

namespace RestaurantAPI
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        IEnumerable<WeatherForecast> IWeatherForecastService.Get(int results, int minTemp, int maxTemp)
        {
            var rng = new Random();
            return Enumerable.Range(1, results).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(minTemp, maxTemp),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
