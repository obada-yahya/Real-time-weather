namespace Real_time_weather;

public class SunBot : Bot
{
    private readonly float _temperatureThreshold;
    public SunBot(float temperatureThreshold, string message) : base(message)
    {
        _temperatureThreshold = temperatureThreshold;
    }

    public override void Update(LocationWeatherInfo weatherData)
    {
        if(weatherData.Temperature > _temperatureThreshold)
            PrintWeatherCast();
    }
}