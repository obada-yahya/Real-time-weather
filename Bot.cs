namespace RealTimeWeather;

public abstract class Bot
{
    protected string Message { get; set; }

    protected Bot(string message)
    {
        this.Message = message;
    }

    public void PrintWeatherCast()
    {
        Console.WriteLine($"{this.GetType().Name}: \"{this.Message}\"");
    }
}