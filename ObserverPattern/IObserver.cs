namespace Real_time_weather;

public interface IObserver<in T>
{
    public void Update(T data);
}