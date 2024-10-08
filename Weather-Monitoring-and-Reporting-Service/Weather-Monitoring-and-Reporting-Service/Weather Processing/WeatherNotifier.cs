using Weather_Monitoring_and_Reporting_Service.Bots;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class WeatherNotifier : WeatherProcessor
    {
        protected override void NotifyHumidityBot(IWeatherHumidityBot humidityBot, double humidity)
        {
            humidityBot.CheckHumidityThreshold(humidity);
        }
        protected override void NotifyTemperatureBot(IWeatherTemperatureBot temperatureBot, double temperature)
        {
            temperatureBot.CheckTemperatureThreshold(temperature);
        }
        public override void AddHumidityBot(IWeatherHumidityBot humidityBot)
        {
            HumidityBots.Add(humidityBot);
        }
        public override void RemoveHumidityBot(IWeatherHumidityBot humidityBot)
        {
            HumidityBots.Remove(humidityBot);
        }
        public override void AddTemperatureBot(IWeatherTemperatureBot temperatureBot)
        {
            TemperatureBots.Add(temperatureBot);
        }
        public override void RemoveTemperatureBot(IWeatherTemperatureBot temperatureBot)
        {
            TemperatureBots.Remove(temperatureBot);
        }
        public override void AddWeatherData(string data, IInputWeatherDataParser inputParser)
        {
            AddWeatherData(inputParser.Deserialize(data) ?? throw new ArgumentException("Make sure that the file format is supported!"));
        }
        protected override void AddWeatherData(WeatherData data)
        {
            Data.Add(data);
            NotifyAllTemperatureBots(data.Temperature);
            NotifyAllHumidityBots(data.Humidity);
        }
        protected override void RemoveWeatherData(WeatherData data)
        {
            Data.Remove(data);
        }
        protected override void NotifyAllHumidityBots(double humidity)
        {
            HumidityBots.ForEach(bot => NotifyHumidityBot(bot, humidity));
        }
        protected override void NotifyAllTemperatureBots(double temperature)
        {
            TemperatureBots.ForEach(bot => NotifyTemperatureBot(bot, temperature));
        }
    }
}
