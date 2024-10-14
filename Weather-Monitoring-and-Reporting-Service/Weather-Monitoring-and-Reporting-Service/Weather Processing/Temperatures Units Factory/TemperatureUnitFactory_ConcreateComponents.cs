using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public static class TemperatureUnitFactory_ConcreateComponents
    {
        private static readonly Dictionary<string, ITemperatureUnitFactory> factories = [];

        static TemperatureUnitFactory_ConcreateComponents()
        {
            AddTemperatureUnit("Celsius", new CelsiusFactory());
            AddTemperatureUnit("Fahrenheit", new FahrenheitFactory());
            AddTemperatureUnit("Kelvin", new KelvinFactory());
        }

        public static void AddTemperatureUnit(string unitName, ITemperatureUnitFactory factory)
            => factories.Add(unitName, factory);

        public static ITemperatureUnit Create(string unitName)
        {
            return factories.ContainsKey(unitName) ? factories[unitName].Create() :
                   throw new ArgumentException($"Unknown temperature unit: {unitName}");
        }
    }
}
