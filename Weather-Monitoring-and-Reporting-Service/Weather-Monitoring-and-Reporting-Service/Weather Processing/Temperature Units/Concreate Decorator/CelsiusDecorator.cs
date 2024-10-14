using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class CelsiusDecorator : TemperatureUnitDecorator // ConcreateDecorator
    {
        public CelsiusDecorator(ITemperatureUnit temperature) : base(temperature)
        {
            Name = "Celsius";
        }
        public override string Name
        {
            get { return $"{_temperature.Name} -→ {_name} ({Temperature} °C)"; }
            set { _name = value; }
        }
        public override double Temperature
        {
            get => FromCelsius(_temperature.CelsiusTemperature);
            set { }
        }
        protected override double FromCelsius(double temperature) => temperature;
        protected override double ToCelsius(double temperature) => temperature;
    }
}

