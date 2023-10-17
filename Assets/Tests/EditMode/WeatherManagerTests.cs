using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;
using Weather;

public class WeatherManagerTests
{
    [Test]
    public void Get_LocationData_ReturnsPredefinedData()
    {
        var predefinedLocationData = new LocationData()
        {
            latitude = 333,
            longitude = 444
        };

        var mockedLocationService = new MockLocationService();
        mockedLocationService.locationData = predefinedLocationData;

        WeatherManager.DeInit();
        WeatherManager.Init(locationService: mockedLocationService);

        LocationData ld = WeatherManager.GetLocation();

        Assert.AreEqual(predefinedLocationData.longitude, ld.longitude);
        Assert.AreEqual(predefinedLocationData.latitude, ld.latitude);

        WeatherManager.DeInit();
    }

    private class MockLocationService : ILocationService
    {
        public LocationData locationData;

        public bool isRunning;

        public LocationData GetLocation()
        {
            return locationData;
        }

        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}
