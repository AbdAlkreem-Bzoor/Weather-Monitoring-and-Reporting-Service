namespace Weather_Monitoring_and_Reporting_Service.Input
{
    public interface IInputWeatherDataParser
    {
        public string Serialize(IWeatherData weatherData);
        public IWeatherData? Deserialize(string content);
    }
}
