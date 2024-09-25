using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public class RainBot : IWeatherHumidityBot
    {
        protected static IBotFileFormatParser FormatParser { get; set; } = new BotJsonFormatParser();
        private readonly static IWeatherHumidityBot Configuration = Configurations();
        public RainBot()
        {
            Enabled = Configuration is null ? false : Configuration.Enabled;
            HumidityThreshold = Configuration is null ? 0.0 : Configuration.HumidityThreshold;
            Message = Configuration is null ? string.Empty : Configuration.Message;
        }
        public bool Enabled { get; init; }
        public double HumidityThreshold { get; init; }
        public string Message { get; init; }

        public event Action<string>? OnStateChanged = Console.WriteLine;

        public static IWeatherHumidityBot Configurations()
        {
            var content = File.ReadAllText("D:\\OneDrive\\Desktop\\Weather Monitoring and Reporting Service\\Weather-Monitoring-and-Reporting-Service\\Weather-Monitoring-and-Reporting-Service\\Bots\\ConfigurationsFiles\\rainbot.json");
            var config = FormatParser.DeserializeHumidityBot<RainBot>(content);
            if (config is null)
                throw new Exception("Rain Bot, something went wrong!!!");
            return config;
        }

        public void CheckHumidityThreshold(double humidity)
        {
            if (humidity > HumidityThreshold && OnStateChanged is not null)
                OnStateChanged(Message);
        }
    }
}
