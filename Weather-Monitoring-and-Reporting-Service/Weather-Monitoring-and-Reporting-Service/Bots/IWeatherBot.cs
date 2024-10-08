namespace Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IWeatherBot
    {
        protected static IBotFileFormatParser FormatParser { get; set; } = new BotJsonFormatParser();
        public bool Enabled { get; init; }
        public string Message { get; init; }
        public event Action<string>? OnStateChanged;
    }
}
