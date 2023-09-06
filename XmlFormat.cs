using System.Xml.Linq;

namespace RealTimeWeather;

public class XmlFormat : IDataFormat
{
    public LocationWeatherInfo ValidateWeatherData(object format)
    {
        var xml = format as XDocument;
        bool isLocationExist = xml.Root.Element("Location") != null;
        bool isTemperatureExist = xml.Root.Element("Temperature") != null;
        bool isHumidityExist = xml.Root.Element("Humidity") != null;
        if (isLocationExist && isTemperatureExist && isHumidityExist)
        {
            string location = xml.Root.Element("Location").Value;
            bool isValidTemperature = float.TryParse(xml.Root.Element("Temperature").Value, out float temperature);
            bool isValidHumidity = float.TryParse(xml.Root.Element("Humidity").Value, out float humidity);
            if(isValidTemperature && isValidHumidity)
                return new LocationWeatherInfo(location,temperature,humidity);
            throw new Exception("Invalid data type for numeric type");
        }
        throw new Exception("Data is missing. Please provide the required data.");
    }
    
    public LocationWeatherInfo? GetWeatherData(string format)
    {
        try
        {
            XDocument xml = XDocument.Parse(format);
            LocationWeatherInfo data = ValidateWeatherData(xml);
            return data;
        }
        catch (System.Xml.XmlException exception)
        {
            Console.WriteLine("Invalid Xml Format");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return null;
    }
}