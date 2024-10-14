using System.Text.Json;
using Weather_Monitoring_and_Reporting_Service.Bots;

namespace WMARS.Tests
{
    public class BotsFilesParsersFormatsShould
    {
        [Theory]
        [InlineData("{\"Location\": \"City Name\",  \"Temperature\": -25.0,\"Humidity\": 15.0}")]
        public void CheckJsonParserDeserializeMethods(string content)
        {
            var parser = new BotJsonFormatParser();

            Assert.IsType<RainBot>(parser.DeserializeHumidityBot<RainBot>(content));
            Assert.IsType<SunBot>(parser.DeserializeTemperatureBot<SunBot>(content));
            Assert.IsType<SnowBot>(parser.DeserializeTemperatureBot<SnowBot>(content));
            Assert.IsNotAssignableFrom<IWeatherTemperatureBot>(parser.DeserializeHumidityBot<RainBot>(content));
        }
        [Fact]
        public void CheckJsonParserDeserializeMethodsWhenContentIsEmpty()
        {
            var parser = new BotJsonFormatParser();

            Assert.Throws<JsonException>(() => parser.DeserializeTemperatureBot<RainBot>(string.Empty));
        }
        [Fact]
        public void CheckJsonParserDeserializeMethodsWhenContentIsNull()
        {
            var parser = new BotJsonFormatParser();

            Assert.Throws<ArgumentNullException>(() => parser.DeserializeTemperatureBot<RainBot>(null));
        }
    }
}
