using System;
using System.Threading;
using WeatherApp.Service;

namespace WeatherApp.Controller;

public class ConsoleWeatherController : IWeatherController {
    private readonly IWeatherService WeatherService;

    public ConsoleWeatherController(IWeatherService weatherService) {
        WeatherService = weatherService;
    }

    public void RunApp() {
        Console.WriteLine(WeatherService.GetAverageTemperature());
        Console.WriteLine(WeatherService.GetTotalRainfall());
        foreach (var localTemperature in WeatherService.GetLocalTemperatures()) {
            Console.WriteLine(localTemperature);
            Thread.Sleep(100);
        }
    }
}