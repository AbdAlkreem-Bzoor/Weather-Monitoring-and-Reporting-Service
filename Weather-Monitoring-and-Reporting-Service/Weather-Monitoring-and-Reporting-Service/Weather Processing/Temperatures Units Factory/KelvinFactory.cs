using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class KelvinFactory : ITemperatureUnitFactory
    {
        public ITemperatureUnit Create() => new KelvinTemperatureUnit();
        public TemperatureUnitDecorator Create(ITemperatureUnit unit) => new KelvinDecorator(unit);
    }
}
