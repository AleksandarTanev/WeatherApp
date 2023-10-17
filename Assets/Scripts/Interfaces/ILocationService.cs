namespace Weather
{
    public interface ILocationService
    {
        public void Start();
        public void Stop();
        public LocationData GetLocation();
    }
}