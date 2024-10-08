using Weather_Monitoring_and_Reporting_Service;
using Weather_Monitoring_and_Reporting_Service.Bots;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace WMARS.Tests
{
    public class WeatherNotifierShould
    {
        [Fact]
        public void ShouldNotify()
        {
            var weatherNotifier = new WeatherNotifier();

            weatherNotifier.AddHumidityBot(new RainBot());
            weatherNotifier.AddTemperatureBot(new SnowBot());
            weatherNotifier.AddTemperatureBot(new SunBot());

            var data = "{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": -25.0,\r\n  \"Humidity\": 15.0\r\n}";
            weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());

            weatherNotifier.TemperatureBots.ForEach(bot =>
            {
                if (bot is SnowBot)
                {
                    Assert.Raises<string>(message => bot.OnStateChanged += message,
                                          message => bot.OnStateChanged -= message,
                                          () => bot.CheckTemperatureThreshold(-25));
                }
            });

            data = "{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 25.0,\r\n  \"Humidity\": 85.0\r\n}";
            weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());

            weatherNotifier.HumidityBots.ForEach(bot =>
            {
                if (bot is RainBot)
                {
                    Assert.Raises<string>(message => bot.OnStateChanged += message,
                                          message => bot.OnStateChanged -= message,
                                          () => bot.CheckHumidityThreshold(85));
                }
            });

            data = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
            weatherNotifier.AddWeatherData(data, new XMLInputWeatherDataParser());

            weatherNotifier.TemperatureBots.ForEach(bot =>
            {
                if (bot is SunBot)
                {
                    Assert.Raises<string>(message => bot.OnStateChanged += message,
                                          message => bot.OnStateChanged -= message,
                                          () => bot.CheckTemperatureThreshold(32));
                }
            });
        }
    }
}
