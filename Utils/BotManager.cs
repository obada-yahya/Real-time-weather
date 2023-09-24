namespace Real_time_weather.Utils;

public class BotManager
{
    private readonly IFileWeatherReader _fileReader;

    public BotManager(IFileWeatherReader fileReader)
    {
        _fileReader = fileReader;
    }

    public List<Bot> GetActiveBots()
    {
        var botsConfiguration = _fileReader.GetConfigData();
        var activeBots = new List<Bot>();
        var botsConfigurationProperties= botsConfiguration?.GetType().GetProperties();
        if (botsConfigurationProperties is null) return activeBots;
        
        foreach (var botProperty in botsConfigurationProperties )
        {
            var propertyName = botProperty.Name;
            var propertyValue = botProperty.GetValue(botsConfiguration) as BotSettings;
            if (propertyValue is null || !propertyValue.Enabled) continue;
            var bot = BotFactory.GetBot(propertyValue, propertyName);
            if(bot is not null) activeBots.Add(bot);
        }
        return activeBots;
    }
}