using System.Text.Json;
using System.Text.Json.Serialization;
using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace Weather_Monitoring_and_Reporting_Service
{
    public class JSONTemperatureUnitConverter : JsonConverter<ITemperatureUnit>
    {
        public override ITemperatureUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var temperatureUnit = reader.GetString();
            return TemperatureUnitFactory_ConcreateComponents.Create(temperatureUnit);
        }

        public override void Write(Utf8JsonWriter writer, ITemperatureUnit value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }

}
// we can just Deserialize any input formats to the targeted object then Seserialize it to JSON Format