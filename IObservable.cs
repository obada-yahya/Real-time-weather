namespace Real_time_weather;

public interface IObservable
{
    public void Add(IObserver<LocationWeatherInfo> subscriber);
    public void Remove(IObserver<LocationWeatherInfo> subscriber);
    public void Notify();
}