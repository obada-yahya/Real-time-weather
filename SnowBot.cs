namespace RealTimeWeather;

public class SnowBot : Bot
{
    public SnowBot(string message,IObservable weatherObservable) : base(message,weatherObservable)
    {
        
    }

    public override void Update()
    {
        PrintWeatherCast();
    }
}