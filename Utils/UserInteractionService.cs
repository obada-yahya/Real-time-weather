﻿namespace Real_time_weather.Utils;

public static class UserInteractionService
{
    public static void DisplayMenu()
    {
        Console.WriteLine("******************************");
        Console.WriteLine("1.Enter Weather Data."+
                          "\n2.Print Enabled Bots."+
                          "\n3.Update Current Weather Data."+
                          "\n4.Quit Program.");
        Console.WriteLine("******************************");
    }

    public static void UpdateWeatherDataMenu()
    {
        Console.WriteLine("******************************");
        Console.WriteLine("1.Change Temperature."+
                          "\n2.Change Humidity."+
                          "\n3.Quit Update Menu.");
        Console.WriteLine("******************************");
    }

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
            UpdateWeatherDataMenu();
            int.TryParse(Console.ReadLine(), out var userChoice);
            if (userChoice == 1)
            {
                temperature = UpdateFloatAttribute("Temperature") ?? temperature;
            }
            else if (userChoice == 2)
            {
                humidity = UpdateFloatAttribute("Humidity") ?? humidity;
                Console.WriteLine($"Fuck ${humidity}");
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
    public static void EnterWeatherData(ref WeatherStation weatherStation)
    {
        try
        {
            Console.WriteLine("Enter Data In The Any Of The Given Formats (json, xml)");
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

    public static void PrintEnabledBots(List<Bot> enabledBots)
    {
        Console.WriteLine("Available Bots:");
        foreach (var enabledBot in enabledBots)
        {
            Console.WriteLine("** "+ enabledBot);
        }
    }
}