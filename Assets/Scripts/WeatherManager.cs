using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weather
{
    public static class WeatherManager
    {
        public static WeatherMono WeatherMono 
        {
            get
            {
                if (_weatherMono == null)
                {
                    _weatherMono = CreateWeatherMono();
                }

                return _weatherMono;
            }
        }

        private static WeatherMono _weatherMono;

        private static IWeatherProviderService _webComService;
        private static ILocationService _locationService;

        private static bool _isInit;

        public static void Init(IWeatherProviderService webComService = null, ILocationService locationService = null)
        {
            if (_isInit)
            {
                return;
            }

            if (webComService != null)
            {
                _webComService = webComService;

            }
            else
            {
                _webComService = new WeatherProviderService();
            }

            if (locationService != null)
            {
                _locationService = locationService;

            }
            else
            {
                _locationService = new LocationService();
            }

            _locationService.Start();

            _isInit = true;
        }

        public static LocationData GetLocation()
        {
            Init();

            return _locationService.GetLocation();
        }

        public static void GetCurrentWeatherData(Action<WeatherData> callback)
        {
            Init();

            var locationData = GetLocation();

            _webComService.GetWeather(locationData, callback);
        }

        public static void DeInit()
        {
            if (_locationService != null)
            {
                _locationService.Stop();
            }
        }

        private static WeatherMono CreateWeatherMono()
        {
            var newGO = new GameObject();
            newGO.name = "WeatherMono";
            var newWeatherMono = newGO.AddComponent<WeatherMono>();

            return newWeatherMono;
        }
    }
}
