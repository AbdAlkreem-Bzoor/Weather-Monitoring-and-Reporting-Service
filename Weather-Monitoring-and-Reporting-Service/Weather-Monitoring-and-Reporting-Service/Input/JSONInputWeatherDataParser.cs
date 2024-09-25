using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using System.Text.Json;

namespace Weather_Monitoring_and_Reporting_Service.Input
{
    public class JSONInputWeatherDataParser : IInputWeatherDataParser
    {
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
        public string Serialize(WeatherData weatherData)
        {
            return System.Text.Json.JsonSerializer.Serialize(weatherData, _options);
        }

        public WeatherData? Deserialize(string content)
        {
            return System.Text.Json.JsonSerializer.Deserialize<WeatherData>(content);
        }
    }
}
