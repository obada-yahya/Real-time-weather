using System.Text.Json;

namespace RealTimeWeather;

public class BotsConfiguration
{
    public BotSettings RainBot { get; init; }
    public BotSettings SunBot { get; init; }
    public BotSettings SnowBot { get; init; }
}

public class BotSettings
{
    public bool Enabled { get; init; }
    public int? HumidityThreshold { get; init; }
    public int? TemperatureThreshold { get; init; }
    public string Message { get; init; }
}

public sealed class ConfigFileReader
{
    private readonly string _configFilePath = GetConfigPath();
    private static ConfigFileReader? _instance;
    private ConfigFileReader()
    {
        
    }
    
    public static ConfigFileReader? Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new ConfigFileReader();
            }
            return _instance;
        }
    }

    public BotsConfiguration? GetConfigData()
    {
        try
        {
            var fileContent = File.ReadAllText(_configFilePath);
            var botsConfiguration = JsonSerializer.Deserialize<BotsConfiguration>(fileContent);
            return botsConfiguration;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File Not Found Exception");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return null;
    }

    private static string GetConfigPath()
    {
        var parentPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        return Path.Combine(parentPath, @"files\configurationDetails.json");
    }
}