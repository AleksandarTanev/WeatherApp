using System.Collections;

namespace Weather
{
    public interface IWebComService
    {
        public IEnumerator GetWeather(LocationData locationData, out WeatherData weatherData);
    }
}
