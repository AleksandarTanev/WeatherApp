using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weather;

public class WeatherMono : MonoBehaviour
{
    private void OnDestroy()
    {
        if (WeatherManager.WeatherMono == this)
        {
            // remove
        }
    }
}
