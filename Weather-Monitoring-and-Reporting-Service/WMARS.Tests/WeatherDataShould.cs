using AutoFixture;
using Weather_Monitoring_and_Reporting_Service;

namespace WMARS.Tests
{
    public class WeatherDataShould
    {
        [Fact]
        public void CheckPropertiesAssignmentsThroughTheConstructor()
        {
            var fixture = new Fixture();

            var location = fixture.Create<string>();
            var temperature = fixture.Create<double>();
            var humidity = fixture.Create<double>();

            var data = new WeatherData(location, temperature, humidity);

            Assert.Equal(temperature, data.Temperature);
            Assert.Equal(humidity, data.Humidity);
            Assert.Equal(location, data.Location);
        }

        [Fact]
        public void CheckEqualsMethod()
        {
            var fixture = new Fixture();

            var location = fixture.Create<string>();
            var temperature = fixture.Create<double>();
            var humidity = fixture.Create<double>();

            var data = new WeatherData(location, temperature, humidity);

            Assert.True(data.Equals(new WeatherData(location, temperature, humidity)));
            Assert.True(data.Equals(new WeatherData(location, humidity, temperature)));
            Assert.False(data.Equals(new WeatherData($"* {location}", temperature, humidity)));
        }
    }
}
