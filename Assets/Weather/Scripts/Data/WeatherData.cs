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

        public CurrentData current;
        public CurrentDataUnits current_units;

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

        [Serializable]
        public struct CurrentData
        {
            public string time;
            public int interval;
            public float temperature_2m;
        }

        [Serializable]
        public struct CurrentDataUnits
        {
            public string time;
            public string interval;
            public string temperature_2m;
        }

        public override string ToString()
        {
            return $"Lang: {latitude}, Long: {longitude}";
        }
    }
}