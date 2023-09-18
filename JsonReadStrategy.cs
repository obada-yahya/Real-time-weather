using System.Text.Json.Nodes;

namespace RealTimeWeather;

public class JsonReadStrategy : IReadStrategy
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format)
    {
        var types = KeyTypeUtil.GetWeatherInfoKeys();
        var validator = new JsonFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        var json = JsonNode.Parse(format);
        var location = json["Location"].ToString();
        var temperature = float.Parse(json["Temperature"].ToString());
        var humidity = int.Parse(json["Humidity"].ToString());
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}