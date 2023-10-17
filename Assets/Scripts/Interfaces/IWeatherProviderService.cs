using System;
using System.Collections;

namespace Weather
{
    public interface IWeatherProviderService
    {
        public void GetWeather(LocationData locationData, Action<WeatherData> weatherData);
    }
}
