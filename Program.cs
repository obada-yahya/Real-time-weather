using Real_time_weather.Utils;

namespace Real_time_weather;

public record LocationWeatherInfo(string Location, float Temperature,float Humidity);

public enum UserChoice
{
    EnterWeatherData = 1,
    PrintEnabledBots,
    UpdateWeatherData,
    QuitProgram,
    Invalid,
}

public class Program
{
    static void Main()
    {
        var enabledBots = UserInteractionService.GetEnabledBots();
        var weatherStation = UserInteractionService.ConfigWeatherStation(enabledBots);
        while (true)
        {
            UserInteractionUI.DisplayMenu();
            switch (GetUserChoice())
            {
                case UserChoice.EnterWeatherData:
                    UserInteractionService.EnterWeatherData(weatherStation);
                    break;
                case UserChoice.PrintEnabledBots:
                    UserInteractionUI.PrintEnabledBots(enabledBots);
                    break;
                case UserChoice.UpdateWeatherData:
                    if(weatherStation.Location.Equals("N/A")) Console.WriteLine("Doesn't Exist Weather Data To Update.");
                    else UserInteractionService.UpdateWeatherData(weatherStation);
                    break;
                case UserChoice.QuitProgram:
                    Console.WriteLine("The End Of The Program.");
                    return;
                default:
                case UserChoice.Invalid:
                    Console.WriteLine("Try To Enter Valid Choice.");
                    break;
            }
        }
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
}