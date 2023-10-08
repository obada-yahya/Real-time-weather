using Real_time_weather;

namespace RealTimeWeatherTests.TestData;

public class DataFormatTestData
{
    public static IEnumerable<Object[]> ValidateFormatValidTestData
    {
        get
        {
            yield return new object[] { new LocationWeatherInfo("London", 16, 16)};
            yield return new object[] { new LocationWeatherInfo("Bristol", 23, 20)};
            yield return new object[] { new LocationWeatherInfo("Liverpool", 14, 21)};
            yield return new object[] { new LocationWeatherInfo("Leicester", 20, 17)};
            yield return new object[] { new LocationWeatherInfo("York", 22, 16)};
        }
    }
}