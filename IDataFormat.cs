namespace RealTimeWeather;
public interface IDataFormat
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format);
}