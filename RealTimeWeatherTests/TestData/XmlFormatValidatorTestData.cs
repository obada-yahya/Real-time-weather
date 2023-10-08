namespace RealTimeWeatherTests.TestData;

public class XmlFormatValidatorTestData
{
    public static IEnumerable<Object[]> ValidateFormatValidTestData
    {
        get
        {
            yield return new object[] {"<WeatherData><Location>London</Location><Temperature>16</Temperature><Humidity>15</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>Bristol</Location><Temperature>23</Temperature><Humidity>20</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>Liverpool</Location><Temperature>14</Temperature><Humidity>21</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>Leicester</Location><Temperature>20</Temperature><Humidity>17</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>York</Location><Temperature>22</Temperature><Humidity>16</Humidity></WeatherData>"};
        }
    }
    
    public static IEnumerable<Object[]> ValidateFormatInValidTestData
    {
        get
        {
            
            yield return new object[] {"<WeatherData><Temperature>16</Temperature><Humidity>15</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Locion>York</Locion><Temperature>23</Temperature><Humidity>16</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>Liverpool</Location><Humidity>21</Humidity></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>Liverpool</Location><Temperature>23</Temperature></WeatherData>"};
            yield return new object[] {"<WeatherData><Location>York</Location><Temperature>str</Temperature><Humidity>16</Humidity></WeatherData>"};
        }
    }
}