namespace RealTimeWeather;

public interface IReadStrategy
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format);
}