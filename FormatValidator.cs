using System.ComponentModel.Design;
using System.Text.Json.Nodes;

namespace RealTimeWeather;
public static class FormatValidator
{
    private static bool JsonContainsAllKeys(JsonObject json, string[] keys)
    {
        foreach (var key in keys)
        {
            if (!json.ContainsKey(key))
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool IsValidKeyValues(JsonObject json, Tuple<string,string>[]attributes)
    {
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
    
    public static bool ValidateJsonFormat(string format,Tuple<string,string>[]attributes)
    {
        try
        {
            JsonObject json = JsonObject.Parse(format) as JsonObject;
            string[] keys = (from entry in attributes select entry.Item1).ToArray();
            if(!JsonContainsAllKeys(json, keys)) throw new Exception("JSON is missing attributes.");
            if(!IsValidKeyValues(json, attributes)) throw new Exception("Invalid data types for the given keys.");
            Console.WriteLine("JSON format is valid for all specified attributes.");
            return true;
        }
        catch (System.Text.Json.JsonException exception)
        {
            Console.WriteLine("Invalid Json Format");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return false;
    }
}