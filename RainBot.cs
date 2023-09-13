namespace RealTimeWeather;

public class RainBot : Bot
{
    public RainBot(string message,IObservable weatherObservable) : base(message,weatherObservable)
    {
        
    }

    public override void Update()
    {
        PrintWeatherCast();
    }
}