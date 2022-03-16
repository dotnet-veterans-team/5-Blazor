using BlazorWebAssembly.Models;

namespace BlazorWebAssembly.Interfaces
{
    public interface IWeatherForecastService : IService
    {
        Task<WeatherForecast[]> GetAllWithPositiveTemperatureAsync();
    }
}
