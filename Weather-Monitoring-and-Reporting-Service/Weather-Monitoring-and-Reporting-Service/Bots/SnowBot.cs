﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public class SnowBot : IWeatherTemperatureBot
    {
        protected static IBotFileFormatParser FormatParser { get; set; } = new BotJsonFormatParser();
        private readonly static IWeatherTemperatureBot Configuration = Configurations();
        public SnowBot()
        {
            Enabled = Configuration is null ? false : Configuration.Enabled;
            TemperatureThreshold = Configuration is null ? 0.0 : Configuration.TemperatureThreshold;
            Message = Configuration is null ? string.Empty : Configuration.Message;
        }
        public bool Enabled { get; init; }
        public double TemperatureThreshold { get; init; }
        public string Message { get; init; }

        public event Action<string>? OnStateChanged = Console.WriteLine;

        public static IWeatherTemperatureBot Configurations()
        {
            var content = File.ReadAllText("D:\\OneDrive\\Desktop\\Weather Monitoring and Reporting Service\\Weather-Monitoring-and-Reporting-Service\\Weather-Monitoring-and-Reporting-Service\\Bots\\ConfigurationsFiles\\snowbot.json");
            var config = FormatParser.DeserializeTemperatureBot<SnowBot>(content);
            if (config is null)
                throw new Exception("Snow Bot, something went wrong!!!");
            return config;
        }

        public void CheckTemperatureThreshold(double temperature)
        {
            if (temperature < TemperatureThreshold && OnStateChanged is not null)
                OnStateChanged(Message);
        }
    }
}
