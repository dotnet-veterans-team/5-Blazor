using AutoMapper;
using BlazorWebAssembly.Models;
using BlazorWebAssembly.Services.Shared;

namespace BlazorWebAssembly.Interfaces
{
    public interface IService
    {
        Task<WeatherForecast[]> GetAllAsync();

        Task<ResponseService> Update<T>(T data);
        void InitializeAsync(HttpClient httpClient, IMapper mapper);
    }
}
