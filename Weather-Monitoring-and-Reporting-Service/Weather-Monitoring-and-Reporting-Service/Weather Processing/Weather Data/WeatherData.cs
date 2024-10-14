using System.Text.Json.Serialization;
using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{

    public class WeatherData : IWeatherData
    {
        public WeatherData() { TemperatureUnit = new CelsiusTemperatureUnit(); }
        public WeatherData(string location, double temperature, double humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
            TemperatureUnit = new CelsiusTemperatureUnit();
            TemperatureUnit.Temperature = temperature;
        }
        public string Location { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        [JsonConverter(typeof(JSONTemperatureUnitConverter))]
        public ITemperatureUnit TemperatureUnit { get; set; }
        public override bool Equals(object? obj)
        {
            var other = obj as WeatherData;
            if (other is null)
                return false;
            return Location.Equals(other.Location);
        }
        public override int GetHashCode() => HashCode.Combine(Location);
        public override string ToString()
        {
            return $"{nameof(Location)} : {Location}\n" +
                   $"{nameof(Temperature)} : {Temperature}\n" +
                   $"{nameof(Humidity)} : {Humidity}\n" +
                   $"{nameof(TemperatureUnit)}: {TemperatureUnit}";
        }
    }
}
