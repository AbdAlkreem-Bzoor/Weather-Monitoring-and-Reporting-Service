namespace Weather_Monitoring_and_Reporting_Service.Input
{
    public interface IInputWeatherDataParser
    {
        public string Serialize(WeatherData weatherData);
        public WeatherData? Deserialize(string content);
    }
}
