namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IBotFileFormatParser
    {
        public IWeatherTemperatureBot? DeserializeTemperatureBot<T>(string content);
        public IWeatherHumidityBot? DeserializeHumidityBot<T>(string content);
    }
}
