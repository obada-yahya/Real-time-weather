namespace Real_time_weather;
public class SnowBot : Bot
{
    private readonly float _temperatureThreshold;
    public SnowBot(float temperatureThreshold, string message) : base(message)
    {
        _temperatureThreshold = temperatureThreshold;
    }

    public override void Update(LocationWeatherInfo weatherData)
    {
        if(weatherData.Temperature < _temperatureThreshold)
            PrintWeatherCast();
    }
}