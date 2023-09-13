using System.Xml.Linq;
namespace RealTimeWeather;
public class XmlFormatValidator : FormatValidator
{
    protected override List<string> ContainsAllKeys(object format, string[] keys)
    {
        var xml = format as XDocument;
        var missingKeys = new List<string>();
        foreach (var key in keys)
        {
            if (xml.Root.Element(key) is null)
            {
                missingKeys.Add(key);
            }
        }
        return missingKeys;
    }

    protected override List<string> IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        var xml = format as XDocument;
        List<string> invalidKeys = new List<string>();
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(xml.Root.Element(attribute.Item1).Value, out _))
                {
                    invalidKeys.Add(attribute.Item1);
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(xml.Root.Element(attribute.Item1).Value, out _))
                {
                    
                    invalidKeys.Add(attribute.Item1);
                }
            }
        }
        return invalidKeys;
    }

    public override bool ValidateFormat(string format, Tuple<string, string>[] attributes)
    {
        try
        {
            var xml = XDocument.Parse(format);
            var keys = (from entry in attributes select entry.Item1).ToArray();
            List<string> missingKeys = ContainsAllKeys(xml, keys);
            if (missingKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', missingKeys);
                throw new Exception("Xml is missing the following attributes:"+message);
            }
            List<string> invalidKeys = IsValidKeyValues(xml, attributes);
            if (invalidKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', invalidKeys);
                throw new Exception("Invalid data types for the given keys:" + message);
            }
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