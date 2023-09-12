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
    public bool enabled { get; init; }
    public int? humidityThreshold { get; init; }
    public int? temperatureThreshold { get; init; }
    public string message { get; init; }
}

public sealed class ConfigFileReader
{
    private string _configFilePath = GetConfigPath();
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
            string fileContent = File.ReadAllText(_configFilePath);
            BotsConfiguration? botsConfiguration = JsonSerializer.Deserialize<BotsConfiguration>(fileContent);
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
        string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        return Path.Combine(parentPath,@"files\configurationDetails.json");
    }
}