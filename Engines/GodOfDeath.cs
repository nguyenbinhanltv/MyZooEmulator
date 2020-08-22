using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MyZooEmulator.Repo;
using MyZooEmulator.Weather;

namespace MyZooEmulator.Engines
{
    class GodOfDeath
    {
        private Timer _timer;
        private WeatherType _weather;
        
        private int Days { get; set; }
        public int Period { get; set; }
        public ZooRepo Zoo { get; set; }

        public GodOfDeath()
        {
            _timer = new Timer();
            Days = 0;
        }

        public GodOfDeath(ZooRepo zoo, int period)
        {
            Period = period;
            Zoo = zoo;
            SetWatchPeriod(Period);
            WatchFor(Zoo);
            WakeUp();
        }

        public void SetWatchPeriod(int period)
        {
            Period = period;
            _timer = new Timer(Period);
        }

        public void WatchFor(ZooRepo zoo)
        {
            Zoo = zoo;
            _timer.Elapsed += (sender, e) =>
            {
                TouchSomebody(sender, e, Zoo);
                Days++;
                RandomWeather(Days);
            };
        }

        public void RandomWeather(int days)
        {
            var max = Enum.GetValues(typeof(WeatherType)).Length;
            _weather = (WeatherType) new Random().Next(0, max);
            Renderer.PrintWeather($"Ngày {days}: {_weather}");
        }

        public void WakeUp()
        {
            _timer.Enabled = true;
        }

        public void Asleep()
        {
            _timer.Enabled = false;
        }

        private void TouchSomebody(object source, ElapsedEventArgs e, ZooRepo zoo)
        {
            var victim = zoo.GetRandomAnimal();
            if (victim != null)
            {
                victim.ChangeStatus();
            }
        }
    }
}
