using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherApp.Repository;
using WeatherApp.Repository.Domain;
using WeatherApp.Service;

namespace WeatherApp.Test.Service;

public class DefaultWeatherServiceTest {
    private const string StationNameTemplate = "Station {0}";

    private Mock<IWeatherRepository> MockRepository;
    private IWeatherService UnderTest;

    [SetUp]
    public void Setup() {
        MockRepository = new Mock<IWeatherRepository>();
        UnderTest = new DefaultWeatherService(MockRepository.Object);
    }

    [Test]
    public void ReceivedValidAverageTemperatureResult() {
        var station1 = BuildStation("1", 1);
        var station2 = BuildStation("2", 2);
        var station3 = BuildStation("3", 3);
        var resultSet = BuildResultSet(station1, station2, station3);

        MockRepository.Setup(repository => repository.GetAverageTemperatures()).Returns(resultSet);

        var temperature = UnderTest.GetAverageTemperature();

        Assert.AreEqual((1 + 2 + 3) / 3, temperature.GetTemperature());
    }

    [Test]
    public void ReceivedValidRainfallResult() {
        var from = DateTime.Now;
        var to = DateTime.Now;

        var value1 = BuildValue(1);
        var value2 = BuildValue(2);
        var result = BuildResult(
            from.Ticks / TimeSpan.TicksPerMillisecond,
            to.Ticks / TimeSpan.TicksPerMillisecond,
            value1,
            value2);

        MockRepository.Setup(repository => repository.GetTotalRainfall()).Returns(result);

        var rainfall = UnderTest.GetTotalRainfall();

        Assert.AreEqual(1 + 2, rainfall.GetRainfall());
        Assert.AreEqual(from.ToShortDateString(), rainfall.GetFrom());
        Assert.AreEqual(to.ToShortDateString(), rainfall.GetTo());
    }

    [Test]
    public void ReceivedValidLocalTemperatureResult() {
        var station1 = BuildStation("1", 1);
        var station2 = BuildStation("2", 2);
        var station3 = BuildStation("3", 3);
        var resultSet = BuildResultSet(station1, station2, station3);

        MockRepository.Setup(repository => repository.GetAverageTemperatures()).Returns(resultSet);

        var localTemperatures = UnderTest.GetLocalTemperatures();

        Assert.AreEqual(station1.Value[0].Value, localTemperatures[0].GetTemperature());
        Assert.AreEqual(station1.Name, localTemperatures[0].GetName());
        Assert.AreEqual(station2.Value[0].Value, localTemperatures[1].GetTemperature());
        Assert.AreEqual(station2.Name, localTemperatures[1].GetName());
        Assert.AreEqual(station3.Value[0].Value, localTemperatures[2].GetTemperature());
        Assert.AreEqual(station3.Name, localTemperatures[2].GetName());
    }

    private Task<WeatherResultSet> BuildResultSet(params WeatherStation[] weatherStation) {
        var stationList = new List<WeatherStation>();
        stationList.AddRange(weatherStation);

        var resultSet = new WeatherResultSet();
        resultSet.Station = stationList;

        return Task.FromResult(resultSet);
    }

    private WeatherStation BuildStation(string name, int temperature) {
        var valueList = new List<WeatherValue>();
        valueList.Add(BuildValue(temperature));

        var station = new WeatherStation();
        station.Name = name;
        station.Value = valueList;

        return station;
    }

    private Task<WeatherResult> BuildResult(long from, long to, params WeatherValue[] weatherValues) {
        var weatherPeriod = new WeatherPeriod();
        weatherPeriod.From = from;
        weatherPeriod.To = to;

        var valueList = new List<WeatherValue>();
        valueList.AddRange(weatherValues);

        var result = new WeatherResult();
        result.Period = weatherPeriod;
        result.Value = valueList;

        return Task.FromResult(result);
    }

    private WeatherValue BuildValue(int temperature) {
        var value = new WeatherValue();
        value.Value = temperature + "";

        return value;
    }
}