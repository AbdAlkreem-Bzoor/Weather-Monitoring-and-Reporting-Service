using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    //which is the default of Temperature Units --> Center --> Celsius
    public class CelsiusTemperatureUnit : ITemperatureUnit // ConcreateComponent
    {
        public double Temperature { get; set; }
        public string Name { get => $"Celsius ({Temperature}°C)"; set { } }
        public double CelsiusTemperature { get => Temperature; set { } }
    }
}

// we could add more classes as a default, like Kelvin unit, etc