using DeviceNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weather;

public class WeatherAppController : MonoBehaviour
{
    [SerializeField] private NotificationWidget _notificationWidget;

    private void Start()
    {
        if (_notificationWidget != null)
        {
            _notificationWidget.SetDelayedMessageProvider(Asd);
        }
    }

    private void Asd(Action<string> callback)
    {
        WeatherManager.GetWeatherData((weatherData) =>
        {
            callback.Invoke(weatherData.GetCurrentTemperature());
        });
    }
}
