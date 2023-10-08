using System.Xml.Linq;

namespace Real_time_weather.Validators;

public class XmlFormatValidator : FormatValidator
{
    protected override List<string> ContainsAllKeys(object format, string[] keys)
    {
        var xml = format as XDocument;
        if (xml is null) throw new System.Xml.XmlException("Invalid Xml Format");
        var missingKeys = (from key in keys where xml.Root.Element(key) is null select key);
        return missingKeys.ToList();
    }

    protected override List<string> IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        var xml = format as XDocument;
        if (xml is null) throw new System.Xml.XmlException("Invalid Xml Format");
        var invalidKeys = new List<string>();
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(xml.Root?.Element(attribute.Item1)?.Value, out _))
                {
                    invalidKeys.Add(attribute.Item1);
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(xml.Root?.Element(attribute.Item1)?.Value, out _))
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
            var missingKeys = ContainsAllKeys(xml, keys);
            if (missingKeys.Any())
            {
                var message = "\n" + string.Join(',', missingKeys);
                throw new Exception("Xml is missing the following attributes:"+message);
            }
            var invalidKeys = IsValidKeyValues(xml, attributes);
            if (invalidKeys.Any())
            {
                var message = "\n" + string.Join(',', invalidKeys);
                throw new Exception("Invalid data types for the given keys:" + message);
            }
            Console.WriteLine("Xml format is valid for all specified attributes.");
            return true;
        }
        catch (System.Xml.XmlException)
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