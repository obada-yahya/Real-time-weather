using System.Text.Json;
using BotsConfiguration = Real_time_weather.Utils.BotsConfiguration;

namespace Real_time_weather.Utils;

public sealed class ConfigFileReader
{
    private readonly string _configFilePath = GetConfigPath();
    private static ConfigFileReader? _instance;
    
    private ConfigFileReader()
    {
        
    }
    
    public static ConfigFileReader Instance
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
        catch (FileNotFoundException)
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
        if (parentPath == null) throw new Exception("Invalid File Path");
        return Path.Combine(parentPath, @"files\configurationDetails.json");
    }
}