using Real_time_weather.Utils;

namespace Real_time_weather
{
    public record LocationWeatherInfo(string Location, float Temperature,float Humidity);
    public class Program
    {
        static void Main(string[] args)
        {
            var botManager = new BotManager(ConfigFileReader.Instance);
            var enabledBots = botManager.GetActiveBots();
            WeatherStation? weatherStation = null;
            while (true)
            {
                UserInteractionService.DisplayMenu();
                int.TryParse(Console.ReadLine(), out var userChoice);
                if (userChoice == 1)
                {
                    UserInteractionService.EnterWeatherData(ref weatherStation);
                }
                else if (userChoice == 2)
                {
                    UserInteractionService.PrintEnabledBots(enabledBots);
                }
                else if (userChoice == 3)
                {
                    UserInteractionService.UpdateWeatherData(weatherStation);
                }
                else if(userChoice == 4)
                {
                    Console.WriteLine("The End Of The Program.");
                    break;
                }
                else
                {
                    Console.WriteLine("Try To Enter Valid Choice.");
                }
            }
        }
    }
}