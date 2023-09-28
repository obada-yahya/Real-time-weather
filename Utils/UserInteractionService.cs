namespace Real_time_weather.Utils;

public enum UserChoice
{
    ChangeTemperature = 1,
    ChangeHumidity,
    QuitUpdateMenu,
    Invalid,
}

public static class UserInteractionService
{
    private static float? UpdateFloatAttribute(string attributeName)
    {
        Console.WriteLine($"Enter The New {attributeName}.");
        if (float.TryParse(Console.ReadLine(), out var value)) return value;
        Console.WriteLine($"Invalid Value For {attributeName}.");
        return null;
    }
    
    private static UserChoice GetUserChoice()
    {
        try
        {
            var userChoice = string.Join("", Console.ReadLine()!.Split(" "));
            var isInt = int.TryParse(userChoice, out var x);
            if(isInt && (x <= 0 || x >= Enum.GetNames(typeof(UserChoice)).Length))
                throw new InvalidOperationException("Numeric Value Out Of Bound.");
            if (Enum.TryParse(userChoice, out UserChoice choice)) return choice;
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Error Occured while Reading Input.");
        }
        return UserChoice.Invalid;
    }

    private static void ChangeWeatherData(WeatherStation weatherStation, float? temperature, float? humidity)
    {
        var location = weatherStation.Location;
        var newTemperature = temperature ?? weatherStation.Temperature;
        var newHumidity = humidity ?? weatherStation.Humidity;
        var weatherInfo = new LocationWeatherInfo(location, newTemperature, newHumidity);
        weatherStation.UpdateWholeWeatherData(weatherInfo);
    }
    
    public static void UpdateWeatherData(WeatherStation weatherStation)
    {
        float? temperature = null;
        float? humidity = null;
        
        while(true)
        {
            UserInteractionUI.UpdateWeatherDataMenu();
            switch (GetUserChoice())
            {
                case UserChoice.ChangeTemperature:
                    temperature = UpdateFloatAttribute("Temperature") ?? temperature;
                    break;
                case UserChoice.ChangeHumidity:
                    humidity = UpdateFloatAttribute("Humidity") ?? humidity;
                    break;
                case UserChoice.QuitUpdateMenu:
                    ChangeWeatherData(weatherStation, temperature, humidity);
                    return;
                default:
                case UserChoice.Invalid:
                    Console.WriteLine("Try To Enter Valid Choice.");
                    break;
            }
        }
    }

    private static List<string> GetAvailableFormats()
    {
        var strategies = ReadStrategiesProvider.GetReadStrategies();
        return (from format in strategies select format.GetType().Name.Split("Read")[0]).ToList();
    }
    
    public static void EnterWeatherData(WeatherStation weatherStation)
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
        try
        {
            var botManager = new BotManager(ConfigFileReader.Instance);
            return botManager.GetActiveBots();
        }
        catch (Exception)
        {
            Console.WriteLine("Failed To Retrieve Active Bots.");
            return new List<Bot>();
        }

    }

    public static WeatherStation ConfigWeatherStation(List<Bot> enabledBots)
    {
        const string defaultLocation = "N/A";
        const float defaultTemperature = -1000;
        const float defaultHumidity = -1000;
        var weatherStation = new WeatherStation(new LocationWeatherInfo(defaultLocation, defaultTemperature,defaultHumidity));
        foreach (var bot in enabledBots) weatherStation.Add(bot);
        return weatherStation;
    }
}