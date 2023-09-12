using System.Text.Json.Nodes;

namespace RealTimeWeather;

public class JsonFormat : IDataFormat
{
    public LocationWeatherInfo? GetWeatherData(string format)
    {
        Tuple<string, string>[] types =
        {
            new Tuple<string, string>("Location", "string"),
            new Tuple<string, string>("Temperature", "float"),
            new Tuple<string, string>("Humidity", "float"),
        };
        JsonFormatValidator validator = new JsonFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        JsonObject json = JsonObject.Parse(format) as JsonObject;
        string location = json["Location"].ToString();
        float temperature = float.Parse(json["Temperature"].ToString());
        float humidity = int.Parse(json["Humidity"].ToString());
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}