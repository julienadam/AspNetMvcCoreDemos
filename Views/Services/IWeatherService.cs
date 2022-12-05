using Views.Models;

namespace Views.Services;

public interface IWeatherService
{
    Task<WeatherData> GetWeatherAsync(string city);
}