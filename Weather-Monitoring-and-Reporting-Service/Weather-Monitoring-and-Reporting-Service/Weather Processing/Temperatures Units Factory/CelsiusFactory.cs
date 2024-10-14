using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class CelsiusFactory : ITemperatureUnitFactory
    {
        public ITemperatureUnit Create() => new CelsiusTemperatureUnit();
        public TemperatureUnitDecorator Create(ITemperatureUnit unit) => new CelsiusDecorator(unit);
    }
}
