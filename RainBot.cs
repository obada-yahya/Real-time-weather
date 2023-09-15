namespace RealTimeWeather;
public class RainBot : Bot
{
    private float _humidityThreshold;
    public RainBot(float humidityThreshold, string message, WeatherStation weatherStation) : base(message, weatherStation)
    {
        _humidityThreshold = humidityThreshold;
    }

    public override void Update()
    {
        if(_weatherObservable.Humidity > _humidityThreshold)
            PrintWeatherCast();
    }
}