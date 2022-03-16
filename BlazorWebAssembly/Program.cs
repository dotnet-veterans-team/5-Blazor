using BlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using BlazorWebAssembly.Interfaces;
using BlazorWebAssembly.Services;
using AutoMapper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => httpClient);

builder.Services.AddBlazoredModal();

builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

var host = builder.Build();

var weatherService = host.Services.GetRequiredService<IWeatherForecastService>();

var configuration = new MapperConfiguration(cfg => { });
var mapper = configuration.CreateMapper();

//await weatherService.InitializeWeatherAsync(host.Configuration["WeatherServiceUrl"], httpClient);

weatherService.InitializeAsync(httpClient, mapper);

await host.RunAsync();
