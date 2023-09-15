namespace RealTimeWeather;
public class SnowBot : Bot
{
    private float _temperatureThreshold;
    public SnowBot(float temperatureThreshold, string message, WeatherStation weatherStation) : base(message, weatherStation)
    {
        _temperatureThreshold = temperatureThreshold;
    }

    public override void Update()
    {
        if(_weatherObservable.Temperature < _temperatureThreshold)
            PrintWeatherCast();
    }
}