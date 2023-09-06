using System.Text.Json.Nodes;

namespace RealTimeWeather;

public class JsonFormat : IDataFormat
{
    public LocationWeatherInfo ValidateWeatherData(object format)
    {
        var json = format as JsonObject;
        bool isLocationExist = json.ContainsKey("Location");
        bool isTemperatureExist = json.ContainsKey("Temperature");
        bool isHumidityExist = json.ContainsKey("Humidity");
        if (isLocationExist && isTemperatureExist && isHumidityExist)
        {
            string location = json["Location"].ToString();
            bool isValidTemperature = float.TryParse(json["Temperature"].ToString(), out float temperature);
            bool isValidHumidity = float.TryParse(json["Humidity"].ToString(), out float humidity);
            if(isValidTemperature && isValidHumidity)
                return new LocationWeatherInfo(location,temperature,humidity);
            throw new Exception("Invalid data type for numeric type");
        }
        throw new Exception("Data is missing. Please provide the required data.");
    }
    
    public LocationWeatherInfo? GetWeatherData(string format)
    {
        Tuple<string, string>[] types =
        {
            new Tuple<string, string>("Location", "string"),
            new Tuple<string, string>("Temperature", "float"),
            new Tuple<string, string>("Humidity", "float"),
        };
        if (!FormatValidator.ValidateJsonFormat(format, types)) return null;
        
        JsonObject json = JsonObject.Parse(format) as JsonObject;
        string location = json["Location"].ToString();
        float temperature = int.Parse(json["Temperature"].ToString());
        float humidity = int.Parse(json["Humidity"].ToString());
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}