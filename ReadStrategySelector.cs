namespace Real_time_weather;

public class ReadStrategySelector
{
    public IReadStrategy GetStrategy(string format)
    {
        var strategies = ReadStrategiesProvider.GetReadStrategies();
        foreach (var strategy in strategies)
        {
            if (strategy.IsValidFormat(format))
            {
                return strategy;
            }
        }
        throw new Exception("No Such Data Format exist in the system.");
    }
}