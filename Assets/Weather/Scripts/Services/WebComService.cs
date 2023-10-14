using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Weather
{
    public class WebComService : IWebComService
    {
        public void GetWeather(LocationData locationData, Action<WeatherData> callback)
        {
            WeatherManager.WeatherMono.StartCoroutine(CheckCurrentWeather(locationData, callback));
        }

        public IEnumerator CheckCurrentWeather(LocationData locationData, Action<WeatherData> callback)
        {
            string url = "https://api.open-meteo.com/v1/forecast";
            Dictionary<string, string> getParams = new Dictionary<string, string>();
            getParams.Add("latitude", locationData.latitude.ToString());
            getParams.Add("longitude", locationData.longitude.ToString());
            getParams.Add("current", "temperature_2m");

            url = AddParamsToUrl(url, getParams);

            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
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
                        WeatherData data = JsonUtility.FromJson<WeatherData>(json);

                        callback?.Invoke(data);

                        break;
                }
            }
        }

        public string AddParamsToUrl(string url, Dictionary<string, string> getParams)
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
}