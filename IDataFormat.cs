namespace RealTimeWeather;

public interface IDataFormat
{
    public LocationWeatherInfo? GetWeatherData(string format);
    protected LocationWeatherInfo ValidateWeatherData(Object format);
}