using System.Collections.Generic;
using WeatherApp.Service.Domain;

namespace WeatherApp.Service;

public interface IWeatherService {
    AverageTemperatureResult GetAverageTemperature();
    RainfallResult GetTotalRainfall();
    IList<LocalTemperatureResult> GetLocalTemperatures();
}