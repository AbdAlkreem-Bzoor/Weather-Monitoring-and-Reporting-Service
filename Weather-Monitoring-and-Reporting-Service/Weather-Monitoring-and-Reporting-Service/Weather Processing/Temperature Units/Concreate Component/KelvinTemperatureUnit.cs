using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class KelvinTemperatureUnit : ITemperatureUnit // ConcreateComponent
    {
        public double Temperature { get; set; }
        public string Name { get => $"Kelvin ({Temperature}°F)"; set { } }
        public double CelsiusTemperature { get => (double)Math.Round(Temperature - 273.15, 2); set { } }
    }
}

// we could add more classes as a default, like Kelvin unit, etc