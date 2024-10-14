using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class FahrenheitDecorator : TemperatureUnitDecorator // ConcreateDecorator
    {
        public FahrenheitDecorator(ITemperatureUnit temperature) : base(temperature)
        {
            Name = "Fahrenheit";
        }
        public override string Name
        {
            get { return $"{_temperature.Name} -→ {_name} ({Temperature} °F)"; }
            set { _name = value; }
        }
        public override double Temperature
        {
            get => FromCelsius(_temperature.CelsiusTemperature);
            set { }
        }
        protected override double FromCelsius(double temperature) => (double)Math.Round(9 * ((double)1 / 5) * temperature + 32, 2);
        protected override double ToCelsius(double temperature) => (double)Math.Round((temperature - 32) * ((double)5 / 9), 2);
    }
}

