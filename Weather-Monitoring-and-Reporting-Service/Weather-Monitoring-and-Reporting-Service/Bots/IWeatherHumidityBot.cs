namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IWeatherHumidityBot : IWeatherBot
    {
        public double HumidityThreshold { get; init; }
        public void CheckHumidityThreshold(double value);
    }
}
