using System.Text.Json.Nodes;

namespace RealTimeWeather;

public class JsonFormatValidator : FormatValidator
{
    protected override bool ContainsAllKeys(object format, string[] keys)
    {
        JsonObject json = format as JsonObject;
        foreach (var key in keys)
        {
            if (!json.ContainsKey(key))
            {
                return false;
            }
        }
        return true;
    }

    protected override bool IsValidKeyValues(object format, Tuple<string, string>[] attributes)
    {
        JsonObject json = format as JsonObject;
        foreach (var attribute in attributes)
        {
            string attributeType = attribute.Item2.ToLower();
            if (attributeType == "int")
            {
                if (!int.TryParse(json[attribute.Item1].ToString(), out _))
                {
                    return false;
                }
            }
            else if (attributeType == "float")
            {
                if (!float.TryParse(json[attribute.Item1].ToString(), out _))
                {
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
            JsonObject json = JsonObject.Parse(format) as JsonObject;
            string[] keys = (from entry in attributes select entry.Item1).ToArray();
            if(!ContainsAllKeys(json, keys)) throw new Exception("JSON is missing attributes.");
            if(!IsValidKeyValues(json, attributes)) throw new Exception("Invalid data types for the given keys.");
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