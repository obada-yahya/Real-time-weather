namespace RealTimeWeather;

public interface IDataFormat
{
    public record Data(string Location, float Temperature,float Humidity);
    public Data? GetData(string format);
    protected IDataFormat.Data ValidateData(Object format);
}