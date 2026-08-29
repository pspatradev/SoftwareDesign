namespace WeatherForecastObserverPullPattern
{
    public class HumStatDisplay : IWeatherSubscriber
    {
        private WeatherForecastStation _station;
        public HumStatDisplay(WeatherForecastStation station)
        {
            _station = station;
            _station.AddSubscriber(this);
        }
        public void Update()
        {
            Console.WriteLine($"[Forecast] Humidity forecast : {_station.GetHumidity() - 1}%");
        }
    }
}
