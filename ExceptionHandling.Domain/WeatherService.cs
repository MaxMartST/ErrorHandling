using ExceptionHandling.Domain.MyExcption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandling.Domain
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> Get(string cityName);
    }

    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(string cityName)
        {
            if (cityName == "Sydney")
            {
                throw new DomainNotFoundException("No weather data for Sydney");
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
