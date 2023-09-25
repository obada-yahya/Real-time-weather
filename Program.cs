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
            var weatherStation = new WeatherStation(new LocationWeatherInfo("N/A",-1000,-1000));
            foreach (var bot in enabledBots)
            {
                weatherStation.Add(bot);
            }
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
                    if(weatherStation.Location.Equals("N/A"))Console.WriteLine("Doesn't Exist Weather Data To Update.");
                    else UserInteractionService.UpdateWeatherData(ref weatherStation);
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