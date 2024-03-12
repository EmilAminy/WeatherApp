using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Controller;
using WeatherApp.Repository;
using WeatherApp.Service;

namespace WeatherApp;

public static class App {
    public static void Main(string[] args) {
        var repository = new SmhiWeatherRepository(new HttpClient());
        var service = new DefaultWeatherService(repository);
        var controller = new ConsoleWeatherController(service);

        var cts = new CancellationTokenSource();
        Task.Run(controller.RunApp, cts.Token);
        Console.ReadKey();
        cts.Cancel();
    }
}