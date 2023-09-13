namespace RealTimeWeather;

public class SunBot : Bot
{
    public SunBot(string message,IObservable weatherObservable) : base(message,weatherObservable)
    {
        
    }

    public override void Update()
    {
        PrintWeatherCast();
    }
}