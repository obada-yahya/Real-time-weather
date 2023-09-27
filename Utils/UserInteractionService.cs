namespace Real_time_weather.Utils;

public static class UserInteractionService
{
    private static float? UpdateFloatAttribute(string attributeName)
    {
        Console.WriteLine($"Enter The New {attributeName}.");
        if (float.TryParse(Console.ReadLine(), out var value))
        {
            return value;
        }
        Console.WriteLine($"Invalid Value For {attributeName}.");
        return null;
    }
    
    public static void UpdateWeatherData(ref WeatherStation weatherStation)
    {
        float? temperature = null;
        float? humidity = null;
        while(true)
        {
            UserInteractionUI.UpdateWeatherDataMenu();
            int.TryParse(Console.ReadLine(), out var userChoice);
            if (userChoice == 1)
            {
                temperature = UpdateFloatAttribute("Temperature") ?? temperature;
            }
            else if (userChoice == 2)
            {
                humidity = UpdateFloatAttribute("Humidity") ?? humidity;
            }
            else if (userChoice == 3)
            {
                var location = weatherStation.Location;
                var newHumidity = humidity ?? weatherStation.Humidity;
                var newTemperature = temperature ?? weatherStation.Temperature;
                var weatherInfo = new LocationWeatherInfo(location, newHumidity, newTemperature);
                weatherStation.UpdateWholeWeatherData(weatherInfo);
                break;
            }
            else
            {
                Console.WriteLine("Try To Enter Valid Choice.");
            }
        }
    }

    private static List<string> GetAvailableFormats()
    {
        var strategies = ReadStrategiesProvider.GetReadStrategies();
        List<string> formats = new List<string>();
        foreach (var strategy in strategies)
        {
            formats.Add(strategy.GetType().Name.Split("Read")[0]);
        }
        return formats;
    }
    
    public static void EnterWeatherData(ref WeatherStation weatherStation)
    {
        try
        {
            var availableFormats = GetAvailableFormats();
            Console.WriteLine($"Enter Data In The Any Of The Given Formats ({string.Join(", ",availableFormats)})");
            var format = Console.ReadLine();
            if (format is null) throw new Exception("Null Value For Data Format");
            
            var readStrategySelector = new ReadStrategySelector();
            var dataFormat = new DataFormat(readStrategySelector.GetStrategy(format));
            var weatherInfo = dataFormat.GetLocationWeatherInfo(format);
            
            if(weatherInfo is null) throw new Exception("Null Value For Weather Info");
            weatherStation.UpdateWholeWeatherData(weatherInfo);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static List<Bot> GetEnabledBots()
    {
        var botManager = new BotManager(ConfigFileReader.Instance);
        return botManager.GetActiveBots();
    }

    public static  WeatherStation ConfigWeatherStation(List<Bot> enabledBots)
    {
        const string defaultLocation = "N/A";
        const float defaultTemperature = -1000;
        const float defaultHumidity = -1000;
        var weatherStation = new WeatherStation(new LocationWeatherInfo(defaultLocation, defaultTemperature,defaultHumidity));
        foreach (var bot in enabledBots)
        {
            weatherStation.Add(bot);
        }
        return weatherStation;
    }
}