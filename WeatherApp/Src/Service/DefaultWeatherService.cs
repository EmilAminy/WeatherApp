using System;
using System.Collections.Generic;
using WeatherApp.Repository;
using WeatherApp.Service.Domain;

namespace WeatherApp.Service;

public class DefaultWeatherService : IWeatherService {
    private readonly IWeatherRepository WeatherRepository;

    public DefaultWeatherService(IWeatherRepository weatherRepository) {
        WeatherRepository = weatherRepository;
    }

    public AverageTemperatureResult GetAverageTemperature() {
        var stations = WeatherRepository.GetAverageTemperatures().Result.Station;
        var totalTemp = 0d;
        var counter = 0;
        foreach (var weatherStation in stations) {
            foreach (var weatherValue in weatherStation.Value) {
                totalTemp += Convert.ToDouble(weatherValue.Value);
                counter++;
            }
        }

        return new AverageTemperatureResult(totalTemp / counter);
    }

    public RainfallResult GetTotalRainfall() {
        var result = WeatherRepository.GetTotalRainfall().Result;
        var values = result.Value;
        var totalRainfall = 0d;
        foreach (var weatherValue in values) {
            totalRainfall += Convert.ToDouble(weatherValue.Value);
        }

        return new RainfallResult(totalRainfall, result.Period.From, result.Period.To);
    }

    public IList<LocalTemperatureResult> GetLocalTemperatures() {
        var stations = WeatherRepository.GetAverageTemperatures().Result.Station;
        var localTemperatures = new List<LocalTemperatureResult>();
        foreach (var station in stations) {
            var locationName = station.Name;
            var locationTemperature = "";
            if (station.Value.Count > 0) {
                locationTemperature = station.Value[0].Value;
            }

            localTemperatures.Add(new LocalTemperatureResult(locationName, locationTemperature));
        }

        return localTemperatures;
    }
}