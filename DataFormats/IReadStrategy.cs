namespace Real_time_weather.DataFormats;

public interface IReadStrategy
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format);
    public bool IsValidFormat(string format);
}