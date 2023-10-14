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
            if (_isInit)
            {
                return;
            }

            _webComService = new WebComService();
            _locationService = new LocationService();
            _notificationService = GetDefaultNotificationService();

            _locationService.Start();

            _isInit = true;
        }

        public static LocationData GetLocation()
        {
            Init();

            return _locationService.GetLocation();
        }

        public static void GetWeatherData(Action<WeatherData> callback)
        {
            Init();

            var locationData = GetLocation();

            _webComService.GetWeather(locationData, callback);
        }

        public static void NotifyUser()
        {
            Init();

            GetWeatherData((weatherData) =>
            {
                _notificationService.NotifyUser(weatherData.ToString());
            });
        }

        public static void DeInit()
        {
            _locationService.Stop();
        }

        private static INotificationService GetDefaultNotificationService()
        {
#if UNITY_EDITOR
    return new UnityNotificationService();
#elif UNITY_ANDROID
    return new AndroidNotificationService();
#else
    return new UnityNotificationService();
#endif
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
