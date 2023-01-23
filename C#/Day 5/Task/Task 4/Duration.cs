using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Duration
    {
        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }


        public Duration()
        {
            Hours = Minutes = Seconds= 0;
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours= hours;
            Minutes= minutes;
            Seconds= seconds;
        }

        public Duration(int seconds)
        {
            Calculate(seconds);
        }

        private void Calculate(int seconds = 0)
        {
            if(seconds == 0)
                seconds = ToSeconds();

            Hours = seconds / 3600;
            seconds %= 3600;

            Minutes = seconds / 60; 
            seconds %= 60;

            Seconds = seconds;
        }

        private int ToSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }

        public static Duration operator +(Duration duration1, Duration duration2)
        {
            return new Duration(duration1.ToSeconds() + duration2.ToSeconds());
        }

        public static Duration operator -(Duration duration1, Duration duration2)
        {
            return new Duration(Math.Abs(duration1.ToSeconds() - duration2.ToSeconds()));
        }

        public static Duration operator ++(Duration duration)
        {
            int m = duration.Minutes + 1;
            if(m == 60)
            {
                return new Duration()
                {
                    Seconds = duration.Seconds,
                    Minutes = 0,
                    Hours = duration.Hours + 1
                };
            }

            return new Duration()
            {
                Seconds = duration.Seconds,
                Minutes = m,
                Hours = duration.Hours
            };
        }

        public static Duration operator --(Duration duration)
        {
            int m = duration.Minutes - 1;
            if (duration.Minutes == -1)
            {
                return new Duration()
                {
                    Seconds = duration.Seconds,
                    Minutes = 59,
                    Hours = duration.Hours - 1
                };
            }

            return new Duration()
            {
                Seconds = duration.Seconds,
                Minutes = m,
                Hours = duration.Hours
            };
        }

        public static bool operator >(Duration duration1, Duration duration2)
        {
            if(duration1.ToSeconds() > duration2.ToSeconds())
                return true;
            return false;
        }

        public static bool operator <(Duration duration1, Duration duration2)
        {
            if (duration1.ToSeconds() < duration2.ToSeconds())
                return true;
            return false;
        }

        public static bool operator >=(Duration duration1, Duration duration2)
        {
            if (duration1.ToSeconds() >= duration2.ToSeconds())
                return true;
            return false;
        }

        public static bool operator <=(Duration duration1, Duration duration2)
        {
            if (duration1.ToSeconds() <= duration2.ToSeconds())
                return true;
            return false;
        }

        public override string ToString()
        {
            if(Hours > 0)
                return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
            
            if (Minutes > 0)
                return $"Minutes: {Minutes}, Seconds: {Seconds}";

            return $"Seconds: {Seconds}";

        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            return Hours == ((Duration)obj).Hours && Minutes == ((Duration)obj).Minutes && Seconds == ((Duration)obj).Seconds;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static implicit operator DateTime (Duration duration)
        {
            var dt = DateTime.Now;
            return new DateTime(dt.Year, dt.Month, dt.Day, duration.Hours, duration.Minutes, duration.Seconds);
        }

        public static implicit operator bool(Duration duration)
        {
            return duration.Hours > 0 || duration.Minutes > 0 || duration.Seconds > 0;
        }

        public static implicit operator Duration(int seconds)
        {
            return new Duration(seconds);
        }
    }
}
