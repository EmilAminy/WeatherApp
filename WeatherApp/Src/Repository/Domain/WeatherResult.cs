using System.Collections.Generic;

namespace WeatherApp.Repository.Domain;

public class WeatherResult {
    public long Updated;
    public WeatherParameter Parameter;
    public WeatherStation Station;
    public WeatherPeriod Period;
    public IList<WeatherPosition> Position;
    public IList<WeatherLink> Link;
    public IList<WeatherValue> Value;
}