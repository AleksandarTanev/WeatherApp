namespace Weather
{
    public interface INotificationService
    {
        public void NotifyUser(WeatherData data);
    }
}