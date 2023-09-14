using System.Xml.Linq;
namespace RealTimeWeather;

public class XmlFormat : IDataFormat
{
    public LocationWeatherInfo? GetLocationWeatherInfo(string format)
    {
        Tuple<string, string>[] types = KeyTypeUtil.GetWeatherInfoKeys();
        var validator = new XmlFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        var xml = XDocument.Parse(format);
        var location = xml.Root.Element("Location").ToString();
        var temperature = int.Parse(xml.Root.Element("Temperature").Value);
        var humidity = int.Parse(xml.Root.Element("Humidity").Value);
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}