using System.Text.Json;
using Weather_Monitoring_and_Reporting_Service.Bots;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class Program
    {
        private readonly static HttpClient httpClient = new HttpClient();
        public static void Main(string[] args)
        {

            var weatherNotifier = new WeatherNotifier();
            weatherNotifier.AddHumidityBot(new RainBot());
            weatherNotifier.AddTemperatureBot(new SnowBot());
            weatherNotifier.AddTemperatureBot(new SunBot());
            var data = "{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": -25.0,\r\n  \"Humidity\": 15.0\r\n}";
            weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());
            data = "{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 25.0,\r\n  \"Humidity\": 85.0\r\n}";
            weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());
            data = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
            weatherNotifier.AddWeatherData(data, new XMLInputWeatherDataParser());


            Console.ReadLine();
        }
    }
}

