namespace RealTimeWeather;

public class SunBot : Bot
{
    private float _temperatureThreshold;
    public SunBot(float temperatureThreshold, string message, WeatherStation weatherStation) : base(message, weatherStation)
    {
        _temperatureThreshold = temperatureThreshold;
    }

    public override void Update()
    {
        if(_weatherObservable.Temperature > _temperatureThreshold)
            PrintWeatherCast();
    }
}