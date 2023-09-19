using System.Xml.Linq;

namespace Real_time_weather;

public class XmlReadStrategy : IReadStrategy
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format)
    {
        var types = KeyTypeUtil.GetWeatherInfoKeys();
        var validator = new XmlFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        var xml = XDocument.Parse(format);
        var location = xml.Root.Element("Location").ToString();
        var temperature = int.Parse(xml.Root.Element("Temperature")?.Value);
        var humidity = int.Parse(xml.Root.Element("Humidity").Value);
        return new LocationWeatherInfo(location, temperature, humidity);
    }

    public bool IsValidFormat(string format)
    {
        try
        {
            var xml = XDocument.Parse(format);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}