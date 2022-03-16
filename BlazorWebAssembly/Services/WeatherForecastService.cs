using AutoMapper;
using BlazorWebAssembly.Helpers;
using BlazorWebAssembly.Interfaces;
using BlazorWebAssembly.Models;
using BlazorWebAssembly.Services.Shared;
using System.Net.Http.Json;

namespace BlazorWebAssembly.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        HttpClient _httpClient;
        IMapper _mapper;

        //public Task InitializeWeatherAsync(string stringToService, HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async void InitializeAsync(HttpClient httpClient, IMapper mapper)
        {
             _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<WeatherForecast[]> GetAllWithPositiveTemperatureAsync()
        {
            WeatherForecast[] responseWeatherForecast = null;

            try
            {
                responseWeatherForecast = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

                responseWeatherForecast = responseWeatherForecast.Where(x => x.TemperatureC >= 0).ToArray();
            }
            catch (Exception e)
            {

                throw;
            }


            return responseWeatherForecast;
        }

        public async Task<WeatherForecast[]> GetAllAsync()
         {
            WeatherForecast[] responseWeatherForecast = null; 

            try
            {
                responseWeatherForecast = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            }
            catch (Exception e)
            {

                throw;
            }
            

             return responseWeatherForecast;
        }

        public async Task<ResponseService> Update<T>(T data)
        {
            try
            {
                var tranformedObject = Transform.KeyValListToObject(data as List<KeyVal<string, string>>);

                WeatherForecast update = _mapper.Map<WeatherForecast>(tranformedObject);

                await _httpClient.PutAsJsonAsync<WeatherForecast>("sample-data/weather.json", update);
            }
            catch (Exception e)
            {
                throw;
            }


            return null;
        }

    }
}
