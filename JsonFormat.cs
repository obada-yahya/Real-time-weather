using System.Text.Json;
using System.Text.Json.Nodes;

namespace RealTimeWeather;

public class JsonFormat : IDataFormat
{
    private IDataFormat.Data ValidateData(JsonObject json)
    {
        bool isLocationExist = json.ContainsKey("Location");
        bool isTemperatureExist = json.ContainsKey("Temperature");
        bool isHumidityExist = json.ContainsKey("Humidity");
        if (isLocationExist && isTemperatureExist && isHumidityExist)
        {
            string location = json["Location"].ToString();
            bool isValidTemperature = float.TryParse(json["Temperature"].ToString(),out float temperature);
            bool isValidHumidity = float.TryParse(json["Humidity"].ToString(),out float humidity);
            if(isValidTemperature && isValidHumidity)
                return new IDataFormat.Data(location,temperature,humidity);
            throw new Exception("Invalid data type for numeric type");
        }
        throw new Exception("Data is missing. Please provide the required data.");
        
    }
    public IDataFormat.Data? GetData(string format)
    {
        try
        {
            JsonObject json = JsonObject.Parse(format) as JsonObject;
            IDataFormat.Data data = ValidateData(json);
            return data;
        }
        catch (System.Text.Json.JsonException exception)
        {
            Console.WriteLine("Invalid Json Format");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return null;
    }
}