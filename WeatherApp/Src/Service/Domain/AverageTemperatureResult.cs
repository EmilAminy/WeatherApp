using System;

namespace WeatherApp.Service.Domain;

public class AverageTemperatureResult {
    private const string AverageTemperatureString =
        "The average temperature in Sweden for the last hours was {0} degrees";

    private readonly double Temperature;

    public AverageTemperatureResult(double temperature) {
        Temperature = Math.Round(temperature, 6);
    }

    public double GetTemperature() {
        return Temperature;
    }

    public override string ToString() {
        return string.Format(AverageTemperatureString, Temperature);
    }
}