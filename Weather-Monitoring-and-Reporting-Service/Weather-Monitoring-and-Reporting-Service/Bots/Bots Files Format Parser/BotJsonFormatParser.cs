using System.Text.Json;

namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public class BotJsonFormatParser : IBotFileFormatParser
    {
        private JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public IWeatherHumidityBot? DeserializeHumidityBot<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content, _options) as IWeatherHumidityBot;
        }

        public IWeatherTemperatureBot? DeserializeTemperatureBot<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content, _options) as IWeatherTemperatureBot;
        }
    }
}
