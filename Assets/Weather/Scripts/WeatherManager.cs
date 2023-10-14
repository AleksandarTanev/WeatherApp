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

        private static IWebComService _webComService;
        private static ILocationService _locationService;
        private static INotificationService _notificationService;

        private static bool _isInit;

        public static void Init()
        {
            _webComService = new WebComService();
            _locationService = new LocationService();
            _notificationService = new NotificationService();

            _locationService.Start();

            _isInit = true;
        }

        public static void TryInit()
        {
            if (!_isInit)
            {
                Init();
            }
        }

        public static LocationData GetLocation()
        {
            TryInit();

            return _locationService.GetLocation();
        }

        public static void GetWeatherData(Action<WeatherData> callback)
        {
            TryInit();

            var locationData = GetLocation();

            _webComService.GetWeather(locationData, callback);
        }

        public static void NotifyUser()
        {
            TryInit();

            GetWeatherData((weatherData) =>
            {
                _notificationService.NotifyUser(weatherData.ToString());
            });
        }

        public static void DeInit()
        {
            _locationService.Stop();
        }

        private static WeatherMono CreateWeatherMono()
        {
            var newGO = new GameObject();
            var newWeatherMono = newGO.AddComponent<WeatherMono>();

            return newWeatherMono;
        }
    }
}
