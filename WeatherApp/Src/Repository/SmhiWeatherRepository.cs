using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Repository.Domain;

namespace WeatherApp.Repository;

public class SmhiWeatherRepository : IWeatherRepository{
    private const string AverageTemperatureUrl =
        "https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station-set/all/period/latest-hour/data.json";

    private const string TotalRainfallUrl =
        "https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/53430/period/latest-months/data.json";

    private readonly HttpClient HttpClient;

    public SmhiWeatherRepository(HttpClient httpClient) {
        HttpClient = httpClient;
    }

    public async Task<WeatherResultSet> GetAverageTemperatures() {
        var response = await HttpClient.GetAsync(AverageTemperatureUrl);
        var body = await response.Content.ReadAsStringAsync();
        var resultSet = JsonConvert.DeserializeObject<WeatherResultSet>(body);
        if (resultSet == null) {
            throw new NullReferenceException();
        }

        return resultSet;
    }

    public async Task<WeatherResult> GetTotalRainfall() {
        var response = await HttpClient.GetAsync(TotalRainfallUrl);
        var body = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<WeatherResult>(body);
        if (result == null) {
            throw new NullReferenceException();
        }

        return result;
    }
}