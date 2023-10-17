using DeviceNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weather;

namespace Weather
{
    public class WeatherAppController : MonoBehaviour
    {
        [SerializeField] private NotificationWidget _notificationWidget;

        private void Start()
        {
            if (_notificationWidget != null)
            {
                _notificationWidget.SetDelayedMessageProvider(DelayedMessageProvider);
            }
        }

        private void DelayedMessageProvider(Action<string> callback)
        {
            WeatherManager.GetCurrentWeatherData((weatherData) =>
            {
                callback.Invoke(GenerateWeatherMessage(weatherData.GetCurrentTemperature()));
            });
        }

        private string GenerateWeatherMessage(string temperature)
        {
            return $"Current temperature is {temperature}";
        }
    }
}
