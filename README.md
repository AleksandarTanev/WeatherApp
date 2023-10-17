## Table of contents
* [General info](#general-info)
* [Usage](#usage)
* [Tests](#tests)
* [Samples](#samples)

## General info
This is a simple app that notifies the user ot the weather temperature at the location he is at.

## Usage
There is a static class *WeatherManager* that can provide you with the current location and the current weather data.
For the notification display a separate package is used:
```
https://github.com/AleksandarTanev/com.bubblebee.device-notifications.git
```
The *WeatherManager* uses two services: *ILocationService* and *IWeatherProviderService*.
These services can be swapped with custom made ones by implementing the corresponding interface and providing the new services to the *WeatherManager* through the *Init()* method.

## Tests
There are a few unity tests added that can be run by using the Unity Test Framework.

## Samples
The project contains a scene (*Main*) that provides an example of the functionality.
Just click the cloud in the middle to receive a notification with the weather info.

The *WeatherAppController* script in the scene sets how the Notification message should be generated.
