namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public class RainBot : IWeatherHumidityBot
    {
        protected static IBotFileFormatParser FormatParser { get; set; } = new BotJsonFormatParser();
        private readonly static IWeatherHumidityBot Configuration = Configurations();
        public RainBot()
        {
            Enabled = Configuration is not null && Configuration.Enabled;
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
            return config is null ? throw new Exception("Rain Bot, something went wrong!!!") : config;
        }

        public void CheckHumidityThreshold(double humidity)
        {
            if (humidity > HumidityThreshold && OnStateChanged is not null)
                OnStateChanged(Message);
        }
    }
}
