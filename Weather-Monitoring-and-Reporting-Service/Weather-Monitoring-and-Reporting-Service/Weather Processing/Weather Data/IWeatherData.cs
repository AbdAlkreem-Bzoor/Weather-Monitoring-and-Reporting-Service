using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public interface IWeatherData
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public ITemperatureUnit TemperatureUnit { get; set; }
    }
}
