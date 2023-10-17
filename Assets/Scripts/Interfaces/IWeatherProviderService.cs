using System;

namespace Weather
{
    public interface IWeatherProviderService
    {
        public void GetWeather(LocationData locationData, Action<WeatherData> weatherData);
    }
}
