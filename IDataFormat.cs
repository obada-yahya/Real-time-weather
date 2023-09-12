namespace RealTimeWeather;

public interface IDataFormat
{
    public LocationWeatherInfo? GetWeatherData(string format);
}