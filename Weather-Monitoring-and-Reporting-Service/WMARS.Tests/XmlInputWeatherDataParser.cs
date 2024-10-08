using Weather_Monitoring_and_Reporting_Service;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace WMARS.Tests
{
    public class XmlInputWeatherDataParser
    {
        private readonly XMLInputWeatherDataParser dataParser;

        public XmlInputWeatherDataParser()
        {
            dataParser = new XMLInputWeatherDataParser();
        }

        [Fact]
        public void CheckSerializeDeserialize()
        {
            var weatherData = new WeatherData("Jenin", 35, 43);
            var outputData = dataParser.Deserialize(dataParser.Serialize(weatherData));

            Assert.NotNull(outputData);
            Assert.Equal(weatherData.Temperature, outputData.Temperature);
            Assert.Equal(weatherData.Location, outputData.Location);
            Assert.Equal(weatherData.Humidity, outputData.Humidity);
        }
    }
}
