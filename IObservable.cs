namespace RealTimeWeather;

public interface IObservable
{
    public void Add(IObserver subscriber);
    public void Remove(IObserver subscriber);
    public void Notify();
}