using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class WeatherApiTest : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(CheckWeather());
    }

    public IEnumerator CheckWeather()
    {
        string url = "https://api.open-meteo.com/v1/forecast";
        Dictionary<string, string> getParams = new Dictionary<string, string>();
        getParams.Add("latitude", "19.07");
        getParams.Add("longitude", "72.87");
        getParams.Add("timezone", "IST");
        getParams.Add("daily", "temperature_2m_max");

        url = AddGETParamsToUrl(url, getParams);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            switch (www.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: ");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error");
                    break;
                case UnityWebRequest.Result.Success:
                    string json = www.downloadHandler.text;

                    Debug.Log("Received: " + json);
                    WeatherResult data = JsonUtility.FromJson<WeatherResult>(json);

                    break;
            }
        }
    }

    public string AddGETParamsToUrl(string url, Dictionary<string, string> getParams)
    {
        if (getParams.Count > 0)
        {
            bool isFirstParam = true;
            foreach (var p in getParams)
            {
                if (isFirstParam)
                {
                    url += $"?{p.Key}={p.Value}";

                    isFirstParam = false;
                }
                else
                {
                    url += $"&{p.Key}={p.Value}";
                }
            }
        }

        return url;
    }
}

[Serializable]
public struct WeatherResult
{
    public float latitude;
    public float longitude;

    public float elevation;
    public float generationtime_ms;

    public int utc_offset_seconds;

    public string timezone;
    public string timezone_abbreviation;

    public TimelyData hourly;
    public TimelyDataUnits hourly_units;

    public TimelyData daily;
    public TimelyDataUnits daily_units;

    [Serializable]
    public struct TimelyData
    {
        public string[] time;
        public float[] temperature_2m_max;
    }

    [Serializable]
    public struct TimelyDataUnits
    {
        public string time;
        public string temperature_2m_max;
    }
}


