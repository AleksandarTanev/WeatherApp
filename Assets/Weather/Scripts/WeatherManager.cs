using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weather
{
    public static class WeatherManager
    {
        private static IWebComService _webComService;
        private static ILocationService _locationService;
        private static INotificationService _notificationService;

        public static void Init()
        {
            _webComService = new WebComService();
            _locationService = new LocationService();
            _notificationService = new NotificationService();

            _locationService.Start();
        }

        public static LocationData GetLocation()
        {
            return _locationService.GetLocation();
        }

        public static WeatherData GetWeatherData()
        {
            var location = GetLocation();

            _webComService.GetWeather(location, out WeatherData data);

            return data;
        }

        public static void NotifyUser()
        {
            _notificationService.NotifyUser(GetWeatherData());
        }

        public static void DeInit()
        {
            _locationService.Stop();
        }
    }
}
