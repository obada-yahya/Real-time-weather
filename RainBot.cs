namespace Real_time_weather;
public class RainBot : Bot
{
    private readonly float _humidityThreshold;
    
    public RainBot(float humidityThreshold, string message) : base(message)
    {
        _humidityThreshold = humidityThreshold;
    }

    public override void Update(LocationWeatherInfo weatherData)
    {
        if(weatherData.Humidity > _humidityThreshold)
            PrintWeatherCast();
    }
}