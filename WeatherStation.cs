namespace RealTimeWeather;

public class WeatherStation : IObservable
{
    private List<IObserver> _subscribers;

    public WeatherStation()
    {
        _subscribers = new List<IObserver>();
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