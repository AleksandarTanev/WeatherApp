using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Weather
{
    [Serializable]
    public struct WeatherData
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
}