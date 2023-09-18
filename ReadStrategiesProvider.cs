using RealTimeWeather;

namespace Real_time_weather;

public static class ReadStrategiesProvider
{
    private static readonly List<IReadStrategy> _strategies = new()
    {
        new JsonReadStrategy(),
        new XmlReadStrategy()
    };

    public static List<IReadStrategy> GetReadStrategies()
    {
        return _strategies;
    }
}