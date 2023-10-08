namespace Real_time_weather.ObserverPattern;

public interface IObserver<in T>
{
    public void Update(T data);
}