using System.Text.Json;

namespace Weather_Monitoring_and_Reporting_Service.Input
{
    public class JSONInputWeatherDataParser : IInputWeatherDataParser
    {
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
        public string Serialize(IWeatherData weatherData)
        {
            return JsonSerializer.Serialize(weatherData, _options);
        }
        public IWeatherData? Deserialize(string content)
        {
            return JsonSerializer.Deserialize<WeatherData>(content);
        }
    }
}
