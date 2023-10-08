using System.Text.Json.Nodes;
using Real_time_weather.Utils;
using Real_time_weather.Validators;

namespace Real_time_weather.DataFormats;

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

    public bool IsValidFormat(string format)
    {
        try
        {
            var json = JsonNode.Parse(format);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}