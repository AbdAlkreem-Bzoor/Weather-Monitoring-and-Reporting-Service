using Weather_Monitoring_and_Reporting_Service.Bots;

namespace WMARS.Tests
{
    public class WeatherBotsShould
    {
        [Fact]
        public void CheckRainBotConfiguration()
        {
            var bot = new RainBot();
            var configuration = RainBot.Configurations();

            Assert.Equal(bot.Enabled, configuration.Enabled);
            Assert.Equal(bot.HumidityThreshold, configuration.HumidityThreshold);
            Assert.Equal(bot.Message, configuration.Message);
        }

        [Fact]
        public void CheckSnowBotConfiguration()
        {
            var bot = new SnowBot();
            var configuration = SnowBot.Configurations();

            Assert.Equal(bot.Enabled, configuration.Enabled);
            Assert.Equal(bot.TemperatureThreshold, configuration.TemperatureThreshold);
            Assert.Equal(bot.Message, configuration.Message);
        }

        [Fact]
        public void CheckSunBotConfiguration()
        {
            var bot = new SunBot();
            var configuration = SunBot.Configurations();

            Assert.Equal(bot.Enabled, configuration.Enabled);
            Assert.Equal(bot.TemperatureThreshold, configuration.TemperatureThreshold);
            Assert.Equal(bot.Message, configuration.Message);
        }
    }
}
