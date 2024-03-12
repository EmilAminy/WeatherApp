using System.Collections.Generic;

namespace WeatherApp.Repository.Domain;

public class WeatherStation {
    public string Key;
    public string Name;
    public string Owner;
    public string OwnerCategory;
    public string MeasuringStations;
    public long From;
    public long To;
    public double Height;
    public double Latitude;
    public double Longitude;
    public IList<WeatherValue> Value;
}