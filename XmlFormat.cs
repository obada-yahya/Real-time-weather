using System.Xml.Linq;

namespace RealTimeWeather;

public class XmlFormat : IDataFormat
{
    public LocationWeatherInfo? GetWeatherData(string format)
    {
        Tuple<string, string>[] types =
        {
            new Tuple<string, string>("Location", "string"),
            new Tuple<string, string>("Temperature", "float"),
            new Tuple<string, string>("Humidity", "float"),
        };
        XmlFormatValidator validator = new XmlFormatValidator();
        if (!validator.ValidateFormat(format, types)) return null;
        
        XDocument xml = XDocument.Parse(format) as XDocument;
        string location = xml.Root.Element("Location").ToString();
        float temperature = int.Parse(xml.Root.Element("Temperature").Value);
        float humidity = int.Parse(xml.Root.Element("Humidity").Value);
        return new LocationWeatherInfo(location, temperature, humidity);
    }
}