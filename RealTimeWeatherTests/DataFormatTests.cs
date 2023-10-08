using Moq;
using Real_time_weather;
using Real_time_weather.DataFormats;
using RealTimeWeatherTests.TestData;

namespace RealTimeWeatherTests;

public class DataFormatTests
{
    [Theory]
    [MemberData(nameof(DataFormatTestData.ValidateFormatValidTestData),
        MemberType = typeof(DataFormatTestData))]
    public void ShouldReturnMatchingWeatherInfo(LocationWeatherInfo actualData)
    {
        var mockReadStrategy = new Mock<IReadStrategy>(MockBehavior.Strict);
        mockReadStrategy.Setup(x => x
            .GetLocationWeatherInfo(It.IsAny<string>()))
            .Returns(actualData);
        var sut = new DataFormat(mockReadStrategy.Object);   
        Assert.Equal(actualData, sut.GetLocationWeatherInfo(FormatWeatherInfoAsJson(actualData)));
    }

    private string FormatWeatherInfoAsJson(LocationWeatherInfo data)
    {
        return '{' + $"\"Location\": \"{data.Location}\"," +
               $" \"Temperature\": {data.Temperature}," +
               $" \"Humidity\": {data.Humidity}" + '}';
    }
}