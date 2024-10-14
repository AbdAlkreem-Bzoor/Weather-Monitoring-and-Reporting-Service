using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class KelvinDecorator : TemperatureUnitDecorator
    {
        public KelvinDecorator(ITemperatureUnit temperature) : base(temperature)
        {
            Name = "Kelvin";
        }
        public override string Name
        {
            get { return $"{_temperature.Name} -→ {_name} ({Temperature} K)"; }
            set { _name = value; }
        }
        public override double Temperature
        {
            get => FromCelsius(_temperature.CelsiusTemperature);
            set { }
        }
        protected override double FromCelsius(double temperature) => (double)Math.Round(temperature + 273.15, 2);
        protected override double ToCelsius(double temperature) => (double)Math.Round(temperature - 273.15, 2);
    }
}

