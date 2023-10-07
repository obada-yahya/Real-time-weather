namespace Real_time_weather.Bots;

public abstract class Bot : ObserverPattern.IObserver<LocationWeatherInfo>
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

    public override string ToString()
    {
        return $"{this.GetType().Name}";
    }
    
    public abstract void Update(LocationWeatherInfo data);
}