namespace Real_time_weather;

public class WeatherStation : IObservable
{
    private readonly List<IObserver<LocationWeatherInfo>> _subscribers;
    private string _location;
    private float _temperature;
    private float _humidity;

    public string Location
    {
        get => _location;
        
        set => _location = value;
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

    public float Humidity
    {
        get => _humidity;
        set
        {
            _humidity = value;
            Notify();
        }
    }

    public void UpdateWholeWeatherData(LocationWeatherInfo weatherInfo)
    {
        _location = weatherInfo.Location;
        _temperature = weatherInfo.Temperature;
        _humidity = weatherInfo.Humidity;
        Notify();
    }
    
    public WeatherStation(LocationWeatherInfo weatherInfo)
    {
        _subscribers = new List<IObserver<LocationWeatherInfo>>();
        UpdateWholeWeatherData(weatherInfo);
    }
    
    public void Add(IObserver<LocationWeatherInfo> subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Remove(IObserver<LocationWeatherInfo> subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    
    public void Notify()
    {
        var data = new LocationWeatherInfo(_location, _temperature, _humidity);
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(data);
        }
    }
}