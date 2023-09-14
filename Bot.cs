namespace RealTimeWeather;

public abstract class Bot : IObserver
{
    protected string _message;
    protected WeatherStation _weatherObservable;

    protected Bot(string message,WeatherStation weatherStation)
    {
        _message = message;
        _weatherObservable = weatherStation;
        _weatherObservable.Add(this);
    }

    public void PrintWeatherCast()
    {
        Console.WriteLine($"{this.GetType().Name}: \"{this._message}\"");
    }

    public abstract void Update();
}