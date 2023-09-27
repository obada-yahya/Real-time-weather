namespace Real_time_weather.Utils;

public static class UserInteractionUI
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
    
    public static void PrintEnabledBots(List<Bot> enabledBots)
    {
        Console.WriteLine("Available Bots:");
        foreach (var enabledBot in enabledBots)
        {
            Console.WriteLine("** "+ enabledBot);
        }
    }
}