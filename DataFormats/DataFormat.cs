namespace Real_time_weather.DataFormats;

public class DataFormat
{
    private IReadStrategy? _readBehavior;

    public DataFormat(IReadStrategy? readBehavior)
    {
        _readBehavior = readBehavior;
    }

    public LocationWeatherInfo? GetLocationWeatherInfo(string format)
    {
        if (_readBehavior is null)
        {
            Console.WriteLine("Non Valid ReadFormat");
            return null;
        }
        return _readBehavior.GetLocationWeatherInfo(format);
    }
}