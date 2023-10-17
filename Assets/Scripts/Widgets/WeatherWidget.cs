using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Weather;

public class WeatherWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private float _refreshTime;

    private float _elapseTime;

    private void Start()
    {
        _elapseTime = _refreshTime;
        WeatherManager.Init();
    }

    private void Update()
    {
        _elapseTime += Time.deltaTime;

        if (_elapseTime >= _refreshTime)
        {
            _elapseTime = 0;
            WeatherManager.GetWeatherData(OnWeatherDataReceived);
        }
    }

    private void OnWeatherDataReceived(WeatherData wd)
    {
        _text.text = wd.current.temperature_2m + wd.current_units.temperature_2m;
    }
}
