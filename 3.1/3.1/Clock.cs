using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    public class Clock
    {
        private Counter _hours;
        private Counter _minutes;
        private Counter _seconds;

        public Clock()
        {
            _hours = new Counter("Hours");
            _minutes = new Counter("Minutes");
            _seconds = new Counter("Seconds");
        }

        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Ticks == 60)
            {
                _seconds.Reset();
                _minutes.Increment();
                if (_minutes.Ticks == 60)
                {
                    _minutes.Reset();
                    _hours.Increment();
                    if (_hours.Ticks == 24)
                    {
                        _hours.Reset();
                        
                    }
                }
            }
        }

        public void Reset()
        {
            _hours.Reset();
            _minutes.Reset();
            _seconds.Reset();
        }

        public string Display()
        {
            Console.WriteLine($"{ _hours.Ticks:D2}: {_minutes.Ticks:D2}: {_seconds.Ticks:D2}");
            return $"{ _hours.Ticks:D2}: {_minutes.Ticks:D2}: {_seconds.Ticks:D2}";
        }
    }
}
