namespace Weather_Monitoring_and_Reporting_Service
{
    public class WeatherData
    {
        public WeatherData() { }
        public WeatherData(string location, double temperature, double humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
        }
        public string Location { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public double Humidity { get; set; }
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
                   $"{nameof(Humidity)} : {Humidity}\n";
        }
    }
}
