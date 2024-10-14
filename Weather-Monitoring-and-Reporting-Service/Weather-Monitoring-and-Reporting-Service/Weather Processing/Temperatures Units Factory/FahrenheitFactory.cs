using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class FahrenheitFactory : ITemperatureUnitFactory
    {
        public ITemperatureUnit Create() => new FahrenheitTemperatureUnit();
        public TemperatureUnitDecorator Create(ITemperatureUnit unit) => new FahrenheitDecorator(unit);
    }
}
