namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IWeatherTemperatureBot : IWeatherBot
    {
        public double TemperatureThreshold { get; init; }
        public void CheckTemperatureThreshold(double value);

    }
}
