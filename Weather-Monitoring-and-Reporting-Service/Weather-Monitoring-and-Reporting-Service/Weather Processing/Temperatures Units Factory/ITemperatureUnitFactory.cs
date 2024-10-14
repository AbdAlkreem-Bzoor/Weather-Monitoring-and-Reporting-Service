using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public interface ITemperatureUnitFactory
    {
        ITemperatureUnit Create();
        TemperatureUnitDecorator Create(ITemperatureUnit unit);
    }
}
