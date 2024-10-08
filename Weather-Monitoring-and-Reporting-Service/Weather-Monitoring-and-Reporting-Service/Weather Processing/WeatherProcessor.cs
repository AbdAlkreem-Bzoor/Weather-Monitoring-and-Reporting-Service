using Weather_Monitoring_and_Reporting_Service.Bots;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace Weather_Monitoring_and_Reporting_Service
{
    public abstract class WeatherProcessor
    {
        public readonly List<IWeatherTemperatureBot> TemperatureBots = [];
        public abstract void AddTemperatureBot(IWeatherTemperatureBot temperatureBot);
        public abstract void RemoveTemperatureBot(IWeatherTemperatureBot temperatureBot);
        protected abstract void NotifyTemperatureBot(IWeatherTemperatureBot temperatureBot, double temperature);

        public readonly List<IWeatherHumidityBot> HumidityBots = [];
        public abstract void AddHumidityBot(IWeatherHumidityBot humidityBot);
        public abstract void RemoveHumidityBot(IWeatherHumidityBot humidityBot);
        protected abstract void NotifyHumidityBot(IWeatherHumidityBot humidityBot, double humidity);

        protected readonly List<WeatherData> Data = [];
        public abstract void AddWeatherData(string data, IInputWeatherDataParser inputParser);
        protected abstract void AddWeatherData(WeatherData data);
        protected abstract void RemoveWeatherData(WeatherData data);

        protected abstract void NotifyAllHumidityBots(double humidity);
        protected abstract void NotifyAllTemperatureBots(double temperature);
    }
}
