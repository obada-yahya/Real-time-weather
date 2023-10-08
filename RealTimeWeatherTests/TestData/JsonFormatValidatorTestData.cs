namespace RealTimeWeatherTests.TestData;

public class JsonFormatValidatorTestData
{
    public static IEnumerable<Object[]> ValidateFormatValidTestData
    {
        get
        {
            yield return new object[] { "{\"Location\":\"London\", \"Temperature\": 16, \"Humidity\": 15}"};
            yield return new object[] { "{\"Location\":\"Bristol\", \"Temperature\": 23, \"Humidity\": 20}"};
            yield return new object[] { "{\"Location\":\"Liverpool\", \"Temperature\": 14, \"Humidity\": 21}"};
            yield return new object[] { "{\"Location\":\"Leicester\", \"Temperature\": 20, \"Humidity\": 17}"};
            yield return new object[] { "{\"Location\":\"York\", \"Temperature\": 22, \"Humidity\": 16}"};
        }
    }
    
    public static IEnumerable<Object[]> ValidateFormatInValidTestData
    {
        get
        {
            yield return new object[] { "\"Temperature\": 16, \"Humidity\": 15}"};
            yield return new object[] { "{\"Locan\":\"London\", \"Temperature\": 23, \"Humidity\": 20}"};
            yield return new object[] { "{\"Location\":\"Liverpool\", \"Humidity\": 21}"};
            yield return new object[] { "{\"Location\":\"Leicester\", \"Temperature\": 20"};
            yield return new object[] { "{\"Location\":\"York\", \"Temperature\": str, \"Humidity\": 16}"};
        }
    }
}