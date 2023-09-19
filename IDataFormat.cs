namespace Real_time_weather;

public interface IDataFormat
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format);
}