namespace RealTimeWeather;

public abstract class Bot : IObserver
{
    protected string _message;
    protected IObservable _weatherObservable;

    protected Bot(string message,IObservable weatherObservable)
    {
        this._message = message;
        this._weatherObservable = weatherObservable;
        this._weatherObservable.Add(this);
    }

    public void PrintWeatherCast()
    {
        Console.WriteLine($"{this.GetType().Name}: \"{this._message}\"");
    }

    public abstract void Update();
}