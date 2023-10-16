using System;
using System.Collections;

namespace Weather
{
    public interface IWebComService
    {
        public void GetWeather(LocationData locationData, Action<WeatherData> weatherData);
    }
}
