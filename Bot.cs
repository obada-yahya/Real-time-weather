namespace Real_time_weather;

public abstract class Bot : IObserver<LocationWeatherInfo>
{
    private readonly string _message;

    protected Bot(string message)
    {
        _message = message;
    }

    public void PrintWeatherCast()
    {
        Console.WriteLine($"{this.GetType().Name}: \"{this._message}\"");
    }

    public abstract void Update(LocationWeatherInfo data);
}