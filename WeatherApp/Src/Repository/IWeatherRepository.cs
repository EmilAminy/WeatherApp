using System.Threading.Tasks;
using WeatherApp.Repository.Domain;

namespace WeatherApp.Repository;

public interface IWeatherRepository {
    Task<WeatherResultSet> GetAverageTemperatures();
    Task<WeatherResult> GetTotalRainfall();
}