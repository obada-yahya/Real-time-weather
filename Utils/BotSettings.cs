namespace Real_time_weather.Utils;

public class BotSettings
{
    public bool Enabled { get; init; }
    public float HumidityThreshold { get; init; }
    public float TemperatureThreshold { get; init; }
    public string Message { get; init; }
}