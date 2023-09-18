using RealTimeWeather;

namespace Real_time_weather;

public interface IReadStrategy
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format);
    public bool IsValidFormat(string format);
}