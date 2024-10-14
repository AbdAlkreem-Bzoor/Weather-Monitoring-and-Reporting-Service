using System.Text.Json;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace WMARS.Tests
{
    public partial class JsonInputWeatherDataParser
    {
        private readonly JSONInputWeatherDataParser dataParser;

        public JsonInputWeatherDataParser()
        {
            dataParser = new JSONInputWeatherDataParser();
        }
        [Fact]
        public void CheckSerializeDeserialize()
        {
            JsonSerializerOptions _options = new() { WriteIndented = true };
            var weatherData = new WeatherDataTest("Jenin", 35, 43);
            var outputData = JsonSerializer.Deserialize<WeatherDataTest>(
                JsonSerializer.Serialize(weatherData, _options));


            Assert.NotNull(outputData);
            Assert.Equal(weatherData.Temperature, outputData.Temperature);
            Assert.Equal(weatherData.Location, outputData.Location);
            Assert.Equal(weatherData.Humidity, outputData.Humidity);
        }
    }
}
