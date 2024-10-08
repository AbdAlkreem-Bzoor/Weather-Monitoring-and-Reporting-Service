using System.Xml;
using System.Xml.Serialization;

namespace Weather_Monitoring_and_Reporting_Service.Input
{
    public class XMLInputWeatherDataParser : IInputWeatherDataParser
    {
        public string Serialize(WeatherData weatherData)
        {
            var result = string.Empty;
            var xmlSerializer = new XmlSerializer(weatherData.GetType());
            using (var output = new StringWriter())
            {
                using (var writer = XmlWriter.Create(output, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(writer, weatherData);
                    result = output.ToString();
                }
            }
            return result;
        }

        public WeatherData? Deserialize(string content)
        {
            WeatherData? weatherData = null;
            var xmlSerializer = new XmlSerializer(typeof(WeatherData));
            using (TextReader reader = new StringReader(content))
            {
                weatherData = xmlSerializer.Deserialize(reader) as WeatherData;
            }
            return weatherData;
        }
    }
}
