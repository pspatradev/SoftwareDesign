using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastObserverPullPattern
{
    public class TempStatDisplay : IWeatherSubscriber
    {
        private WeatherForecastStation _station;
        public TempStatDisplay(WeatherForecastStation station)
        {
            _station = station;
            _station.AddSubscriber(this);
        }
        public void Update()
        {
            Console.WriteLine($"[Forecast] Temperature forecast : {_station.GetTemperature() + 1}C");
        }
    }
}
