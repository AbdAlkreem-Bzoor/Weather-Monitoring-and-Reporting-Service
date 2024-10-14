namespace Weather_Monitoring_and_Reporting_Service.Temperature_Units
{
    public interface ITemperatureUnit // Component
    {
        double Temperature { get; set; }
        string Name { get; set; }
        double CelsiusTemperature { get; set; }
    }
}
