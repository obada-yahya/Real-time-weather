namespace Real_time_weather.Utils;

public static class KeyTypeUtil
{
    public static Tuple<string,string>[] GetWeatherInfoKeys()
    {
        Tuple<string, string>[] weatherInfoKeys =
        {
            new ("Location", "string"),
            new ("Temperature", "float"),
            new ("Humidity", "float"),
        };
        return weatherInfoKeys;
    }
}