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

    [Test]
    public void Use_NotificationService_SendGivenMessage()
    {
        string msg = "test notification message";

       /* var mockNotificationService = new MockNotificationService();

        WeatherManager.DeInit();
        WeatherManager.Init(notificationService: mockNotificationService);

        WeatherManager.NotifyUser();

        LocationData ld = WeatherManager.GetLocation();

        Assert.AreEqual(predefinedLocationData.longitude, ld.longitude);
        Assert.AreEqual(predefinedLocationData.latitude, ld.latitude);
        */
        WeatherManager.DeInit();
    }

    /*
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WeatherManagerTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/

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

    private class MockNotificationService : INotificationService
    {
        public string receivedMessage;

        public void NotifyUser(string msg)
        {
            receivedMessage = msg;
        }
    }
}
