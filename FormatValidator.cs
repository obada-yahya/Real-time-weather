namespace RealTimeWeather;
public abstract class FormatValidator
{
    protected abstract bool ContainsAllKeys(Object format, string[] keys);
    protected abstract bool IsValidKeyValues(Object format, Tuple<string,string>[] attributes);
    public abstract bool ValidateFormat(string format, Tuple<string,string>[] attributes);
}