using System.Collections.Generic;

namespace WeatherApp.Repository.Domain;

public class WeatherResultSet {
    public long updated;
    public WeatherParameter Parameter;
    public WeatherPeriod Period;
    public IList<WeatherLink> Link;
    public IList<WeatherStation> Station;
}