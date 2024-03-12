using System;

namespace WeatherApp.Service.Domain;

public class RainfallResult {
    private const string TotalRainfallString =
        "Between {0} and {1} the total rainfall in Lund was {2} millimeters";

    private readonly double Rainfall;
    private readonly string From;
    private readonly string To;

    public RainfallResult(double rainfall, long from, long to) {
        Rainfall = Math.Round(rainfall, 1);
        From = new DateTime(TimeSpan.FromMilliseconds(from).Ticks).ToShortDateString();
        To = new DateTime(TimeSpan.FromMilliseconds(to).Ticks).ToShortDateString();
    }

    public double GetRainfall() {
        return Rainfall;
    }

    public string GetFrom() {
        return From;
    }

    public string GetTo() {
        return To;
    }

    public override string ToString() {
        return string.Format(TotalRainfallString, From, To, Rainfall);
    }
}