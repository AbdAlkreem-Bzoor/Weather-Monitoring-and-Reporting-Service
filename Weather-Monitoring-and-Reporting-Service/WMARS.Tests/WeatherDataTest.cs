using System.Text.Json.Serialization;
using Weather_Monitoring_and_Reporting_Service;
using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace WMARS.Tests
{
    public partial class JsonInputWeatherDataParser
    {
        class WeatherDataTest : IWeatherData
        {
            public WeatherDataTest(string location, double temperature, double humidity)
            {
                Location = location;
                Temperature = temperature;
                Humidity = humidity;
                TemperatureUnit = new CelsiusTemperatureUnit();
                TemperatureUnit.Temperature = temperature;
            }
            public string Location { get; set; } = string.Empty;
            public double Temperature { get; set; }
            public double Humidity { get; set; }
            [JsonIgnore]
            public ITemperatureUnit TemperatureUnit { get; set; }
        }
    }
}
