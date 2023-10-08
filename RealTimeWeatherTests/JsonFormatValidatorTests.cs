using Real_time_weather.Utils;
using Real_time_weather.Validators;
using RealTimeWeatherTests.TestData;

namespace RealTimeWeatherTests;

public class JsonFormatValidatorTests
{
    [Theory]
    [MemberData(nameof(JsonFormatValidatorTestData.ValidateFormatValidTestData),
        MemberType = typeof(JsonFormatValidatorTestData))]
    public void ValidateFormat_ForValidJson_ReturnTrue(string actualData)
    {
        var validateFormat = new JsonFormatValidator();
        var keys = KeyTypeUtil.GetWeatherInfoKeys();
        var actual = validateFormat.ValidateFormat(actualData, keys);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(JsonFormatValidatorTestData.ValidateFormatInValidTestData),
        MemberType = typeof(JsonFormatValidatorTestData))]
    public void ValidateFormat_forInvalidJson_ReturnFalse(string actualData)
    {
        var validateFormat = new JsonFormatValidator();
        var keys = KeyTypeUtil.GetWeatherInfoKeys();
        var actual = validateFormat.ValidateFormat(actualData, keys);
        Assert.False(actual);
    }
}