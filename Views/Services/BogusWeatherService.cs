using Views.Models;

namespace Views.Services;

public class BogusWeatherService : IWeatherService
{
    public Task<WeatherData> GetWeatherAsync(string city)
    {
        var data = city switch
        {
            "London" => new WeatherData
            {
                City = city,
                Description = "Cloudy with hints of rain. Foggy in the morning.",
                Temp = 12
            },
            "Tokyo" => new WeatherData
            {
                City = city,
                Description = "A beautiful warm sunny day.",
                Temp = 24
            },
            _ => new WeatherData
            {
                City = city,
                Description = "No data for this location",
                Temp = 0
            }
        };

        return Task.FromResult(data);
    }
}