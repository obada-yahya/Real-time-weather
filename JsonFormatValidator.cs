using System.Text.Json.Nodes;
namespace RealTimeWeather;
public class JsonFormatValidator : FormatValidator
{
    protected override List<string> ContainsAllKeys(object format, string[] keys)
    {
        var json = format as JsonObject;
        var missingKeys = new List<string>();
        foreach (var key in keys)
        {
            if (!json.ContainsKey(key))
            {
                missingKeys.Add(key);
            }
        }
        return missingKeys;
    }

    protected override List<string> IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        var json = format as JsonObject;
        List<string> invalidKeys = new List<string>();
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(json[attribute.Item1].ToString(), out _))
                {
                    invalidKeys.Add(attribute.Item1);
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(json[attribute.Item1].ToString(), out _))
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
            var json = JsonObject.Parse(format);
            var keys = (from entry in attributes select entry.Item1).ToArray();
            List<string> missingKeys = ContainsAllKeys(json, keys);
            if (missingKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', missingKeys);
                throw new Exception("JSON is missing the following attributes:"+message);
            }
            List<string> invalidKeys = IsValidKeyValues(json, attributes);
            if (invalidKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', invalidKeys);
                throw new Exception("Invalid data types for the given keys:" + message);
            }
            Console.WriteLine("JSON format is valid for all specified attributes.");
            return true;
        }
        catch (System.Text.Json.JsonException exception)
        {
            Console.WriteLine("Invalid JSON Format");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return false;
    }
}