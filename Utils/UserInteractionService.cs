namespace Real_time_weather.Utils;

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

    public static void UpdateWeatherData(WeatherStation weatherStation)
    {
        try
        {
            if (weatherStation is null) throw new ArgumentNullException("Weather Data Doesn't Exists.");
            UpdateWeatherDataMenu();
            
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
    public static void EnterWeatherData(ref WeatherStation? weatherStation)
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
            if (weatherStation is null) weatherStation = new WeatherStation(weatherInfo);
            else weatherStation.UpdateWholeWeatherData(weatherInfo);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void PrintEnabledBots(List<Bot> enabledBots)
    {
        foreach (var enabledBot in enabledBots)
        {
            Console.WriteLine(enabledBot);
        }
    }
}