using System.Text.Json.Nodes;
namespace RealTimeWeather;
public class JsonFormat : IDataFormat
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format)
    {
        Tuple<string, string>[] types =
        {
            new ("Location", "string"),
            new ("Temperature", "float"),
            new ("Humidity", "float"),
        };
        var validator = new JsonFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        var json = JsonObject.Parse(format);
        var location = json["Location"].ToString();
        var temperature = float.Parse(json["Temperature"].ToString());
        var humidity = int.Parse(json["Humidity"].ToString());
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}