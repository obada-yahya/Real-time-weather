namespace Real_time_weather.Validators;

public abstract class FormatValidator
{
    protected abstract List<string> ContainsAllKeys(Object format, string[] keys);
    protected abstract List<string> IsValidKeyValues(Object format, Tuple<string,string>[] attributes);
    public abstract bool ValidateFormat(string format, Tuple<string,string>[] attributes);
}