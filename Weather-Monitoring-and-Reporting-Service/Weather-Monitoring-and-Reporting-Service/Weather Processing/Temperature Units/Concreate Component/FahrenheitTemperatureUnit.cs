using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class FahrenheitTemperatureUnit : ITemperatureUnit // ConcreateComponent
    {
        public double Temperature { get; set; }
        public string Name { get => $"Fahrenheit ({Temperature}°F)"; set { } }
        public double CelsiusTemperature { get => (double)Math.Round((Temperature - 32) * ((double)5 / 9), 2); set { } }
    }
}

// we could add more classes as a default, like Kelvin unit, etc