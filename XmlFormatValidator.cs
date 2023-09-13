using System.Xml.Linq;
namespace RealTimeWeather;
public class XmlFormatValidator : FormatValidator
{
    protected override bool ContainsAllKeys(object format, string[] keys)
    {
        var xml = format as XDocument;
        foreach (var key in keys)
        {
            if (xml.Root.Element(key) is null)
            {
                return false;
            }
        }
        return true;
    }

    protected override bool IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        var xml = format as XDocument;
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(xml.Root.Element(attribute.Item1).Value, out _))
                {
                    return false;
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(xml.Root.Element(attribute.Item1).Value, out _))
                {
                    Console.WriteLine(attribute.Item1);
                    return false;
                }
            }
        }
        return true;
    }

    public override bool ValidateFormat(string format, Tuple<string, string>[] attributes)
    {
        try
        {
            var xml = XDocument.Parse(format);
            var keys = (from entry in attributes select entry.Item1).ToArray();
            if(!ContainsAllKeys(xml, keys)) throw new Exception("Xml is missing attributes.");
            if(!IsValidKeyValues(xml, attributes)) throw new Exception("Invalid data types for the given keyss.");
            Console.WriteLine("Xml format is valid for all specified attributes.");
            return true;
        }
        catch (System.Xml.XmlException exception)
        {
            Console.WriteLine("Invalid Xml Format");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return false;
    }
}