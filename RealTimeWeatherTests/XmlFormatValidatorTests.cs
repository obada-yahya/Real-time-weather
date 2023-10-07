using Real_time_weather;
using RealTimeWeatherTests.TestData;

namespace RealTimeWeatherTests;

public class XmlFormatValidatorTests
{
    [Theory]
    [MemberData(nameof(XmlFormatValidatorTestData.ValidateFormatValidTestData),
        MemberType = typeof(XmlFormatValidatorTestData))]
    public void ValidateFormat_ForValidXml_ReturnTrue(string actualData)
    {
        var validateFormat = new XmlFormatValidator();
        var keys = KeyTypeUtil.GetWeatherInfoKeys();
        var actual = validateFormat.ValidateFormat(actualData, keys);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(XmlFormatValidatorTestData.ValidateFormatInValidTestData),
        MemberType = typeof(XmlFormatValidatorTestData))]
    public void ValidateFormat_forInvalidXml_ReturnFalse(string actualData)
    {
        var validateFormat = new XmlFormatValidator();
        var keys = KeyTypeUtil.GetWeatherInfoKeys();
        var actual = validateFormat.ValidateFormat(actualData, keys);
        Assert.False(actual);
    }
}