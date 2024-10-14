using System.Text.Json;
using Weather_Monitoring_and_Reporting_Service.Bots;
using Weather_Monitoring_and_Reporting_Service.Input;
using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var weatherNotifier = new WeatherNotifier();

            // Adding weather bots for notifications
            weatherNotifier.AddHumidityBot(new RainBot());
            weatherNotifier.AddTemperatureBot(new SnowBot());
            weatherNotifier.AddTemperatureBot(new SunBot());

            // Adding weather data with the TemperatureUnit field
            var data = "{ \"Location\": \"City Name\", \"Temperature\": -25.0, \"Humidity\": 15.0, \"TemperatureUnit\": \"Fahrenheit\" }";
            weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());

            var unit = weatherNotifier.Data.Last().TemperatureUnit;
            unit.Temperature = -13;
            unit = new CelsiusFactory().Create(unit);

            Console.WriteLine(unit.Name);

            //data = "{ \"Location\": \"City Name\", \"Temperature\": 25.0, \"Humidity\": 85.0, \"TemperatureUnit\": \"Celsius\" }";
            //weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());

            ////data = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity><TemperatureUnit>Celsius</TemperatureUnit></WeatherData>";
            ////weatherNotifier.AddWeatherData(data, new XMLInputWeatherDataParser());

            //data = "{ \"Location\": \"City Name\", \"Temperature\": -25.0, \"Humidity\": 15.0, \"TemperatureUnit\": \"Celsius\" }";
            //weatherNotifier.AddWeatherData(data, new JSONInputWeatherDataParser());

            

            Console.ReadLine();
        }
    }
}

