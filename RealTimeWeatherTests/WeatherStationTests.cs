using AutoFixture;
using Moq;
using Real_time_weather;
using Real_time_weather.WeatherEntities;
namespace RealTimeWeatherTests;


public class WeatherStationTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void Update_ShouldBeCalledOnceForEachSubscriber_WhenNotifyIsTriggered(int numberOfSubscribers)
    {
        var fixture = new Fixture();
        var weatherInfo = new LocationWeatherInfo(fixture.Create<string>(),
            fixture.Create<float>(),fixture.Create<float>());
        var mockSubscribers = GenerateSubscribers(numberOfSubscribers);
        var sut = new WeatherStation(weatherInfo);
        var subscribers = mockSubscribers.ToList();
        foreach (var mockSubscriber in subscribers) sut.Add(mockSubscriber.Object);
        sut.Notify();
        
        foreach (var mockSubscriber in subscribers)
        {
            mockSubscriber.Verify(x 
                => x.Update(It.IsAny<LocationWeatherInfo>()),Times.Once);
        }
    }

    private IEnumerable<Mock<Real_time_weather.ObserverPattern.IObserver<LocationWeatherInfo>>> 
        GenerateSubscribers(int numberOfSubscribers)
    {
        for (var i = 0; i < numberOfSubscribers; i++)
        {
            var mockSubscriber = new Mock<Real_time_weather.ObserverPattern.IObserver<LocationWeatherInfo>>
            (MockBehavior.Strict);
            mockSubscriber.Setup(x =>
                x.Update(It.IsAny<LocationWeatherInfo>()));
            yield return mockSubscriber;
        }
    }
}