using Microsoft.AspNetCore.Mvc;
using Views.Services;

namespace Views.Components
{
    public class WeatherIndicatorViewComponent : ViewComponent
    {
        private readonly IWeatherService weatherService;

        public WeatherIndicatorViewComponent(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string city)
        {
            var data = await weatherService.GetWeatherAsync(city);
            return View("WeatherIndicator", data); // Ici WeatherIndicator.cshtml
        }
    }
}