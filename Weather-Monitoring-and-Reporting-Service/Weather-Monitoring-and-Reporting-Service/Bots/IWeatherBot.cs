using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_and_Reporting_Service.Input;

namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IWeatherBot
    {
        protected static IBotFileFormatParser FormatParser { get; set; } = new BotJsonFormatParser();
        public bool Enabled { get; init; }
        public string Message { get; init; }
        public event Action<string>? OnStateChanged;
        public static (bool enabled, double threshold, string message) Configurations() => (false, 0.0, string.Empty);
    }
}
