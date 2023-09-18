using RealTimeWeather;

namespace Real_time_weather;

public class ReadStrategySelector
{
    public IReadStrategy? GetStrategy(string format)
    {
        var strategies = ReadStrategiesProvider.GetReadStrategies();
        foreach (var strategy in strategies)
        {
            if (strategy.GetLocationWeatherInfo(format) != null)
            {
                return strategy;
            }
        }
        
        return null;
    }
}