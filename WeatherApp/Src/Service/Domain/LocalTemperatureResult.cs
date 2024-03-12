namespace WeatherApp.Service.Domain;

public class LocalTemperatureResult {
    private const string LocalTemperatureString = "{0}: {1}";

    private readonly string Name;
    private readonly string Temperature;

    public LocalTemperatureResult(string name, string temperature) {
        Name = name;
        Temperature = temperature;
    }

    public string GetName() {
        return Name;
    }

    public string GetTemperature() {
        return Temperature;
    }

    public override string ToString() {
        return string.Format(LocalTemperatureString, Name, Temperature);
    }
}