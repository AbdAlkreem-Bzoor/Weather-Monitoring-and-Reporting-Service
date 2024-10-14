using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public abstract class TemperatureUnitDecorator : ITemperatureUnit // Decorator
    {
        protected string _name = string.Empty;
        protected readonly ITemperatureUnit _temperature;
        public TemperatureUnitDecorator(ITemperatureUnit temperature)
        {
            _temperature = temperature;
            CelsiusTemperature = temperature.CelsiusTemperature;
        }
        public abstract string Name { get; set; }
        public abstract double Temperature { get; set; }
        public double CelsiusTemperature { get; set; }
        protected abstract double FromCelsius(double temperature);
        protected abstract double ToCelsius(double temperature);
    }
}
