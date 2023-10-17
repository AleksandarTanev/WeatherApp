using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;
using Weather;

namespace WeatherApp.Tests
{
    public class WeatherProviderServiceTests
    {
        [Test]
        public void Parse_WeatherData_EqualToExpectedResult()
        {
            var weatherProviderService = new WeatherProviderService();

            string json = "{\"latitude\":1.0,\"longitude\":5.0,\"generationtime_ms\":0.08893013000488281,\"utc_offset_seconds\":0,\"timezone\":\"GMT\",\"timezone_abbreviation\":\"GMT\",\"elevation\":0.0,\"current_units\":{\"time\":\"iso8601\",\"interval\":\"seconds\",\"temperature_2m\":\"°C\"},\"current\":{\"time\":\"2023-10-17T12:15\",\"interval\":900,\"temperature_2m\":26.3}}";
            WeatherData wd = weatherProviderService.ParseWeatherData(json);

            Assert.AreEqual(1.0, wd.latitude);
            Assert.AreEqual(5.0, wd.longitude);
            Assert.AreEqual("°C", wd.current_units.temperature_2m);
        }

        [Test]
        public void Add_UrlParams_EqualToExpectedResult()
        {
            var weatherProviderService = new WeatherProviderService();

            string expectedResult = "www.abv.bg?p1=5&p2=Ivan";

            string url = "www.abv.bg";
            Dictionary<string, string> urlParams = new Dictionary<string, string>()
            {
                { "p1", "5" },
                { "p2", "Ivan" },
            };

            var result = weatherProviderService.AddParamsToUrl(url, urlParams);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
