namespace RealTimeWeather;

public class WeatherStation : IObservable
{
    private List<IObserver> _subscribers;
    private string _location;
    private float _temperature;
    private float _humidity;

    public string Location
    {
        get => _location;
        
        set
        {
            _location = value;
        }
    }
    public float Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            Notify();
        }
    }
    public float Humidity => _humidity;

    public WeatherStation(LocationWeatherInfo weatherInfo)
    {
        _subscribers = new List<IObserver>();
        _location = weatherInfo.Location;
        _temperature = weatherInfo.Temperature;
        _humidity = weatherInfo.Humidity;
    }
    public void Add(IObserver subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Remove(IObserver subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }
}