using System.Text.Json.Nodes;

namespace Real_time_weather.Validators;

public class JsonFormatValidator : FormatValidator
{
    protected override List<string> ContainsAllKeys(object format, string[] keys)
    {
        var json = format as JsonObject;
        if (json is null) throw new System.Text.Json.JsonException("Invalid JSON Format");
        var missingKeys = (from key in keys where !json.ContainsKey(key) select key );
        return missingKeys.ToList();
    }

    protected override List<string> IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        var json = format as JsonObject;
        if (json is null) throw new System.Text.Json.JsonException();
        var invalidKeys = new List<string>();
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(json[attribute.Item1]?.ToString(), out _))
                {
                    invalidKeys.Add(attribute.Item1);
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(json[attribute.Item1]?.ToString(), out _))
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
            var json = JsonNode.Parse(format);
            if (json is null) throw new System.Text.Json.JsonException("Invalid JSON Format");
            var keys = (from entry in attributes select entry.Item1).ToArray();
            var missingKeys = ContainsAllKeys(json, keys);
            if (missingKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', missingKeys);
                throw new Exception("JSON is missing the following attributes:"+message);
            }
            var invalidKeys = IsValidKeyValues(json, attributes);
            if (invalidKeys.Count != 0)
            {
                var message = "\n" + string.Join(',', invalidKeys);
                throw new Exception("Invalid data types for the given keys:" + message);
            }
            Console.WriteLine("JSON format is valid for all specified attributes.");
            return true;
        }
        catch (System.Text.Json.JsonException)
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