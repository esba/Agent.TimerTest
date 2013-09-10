using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using System.Threading;

namespace Agent.TimerTest
{
    public class Program
    {
        static Timer _updateMinuteTimer;
        static Timer _updateSecondTimer;

        public static void Main()
        {
            // obtain the current time
            DateTime currentTime = DateTime.Now;

            // set up timer to refresh time every minute
            TimeSpan dueTimeMinute = new TimeSpan(0, 0, 0, 59 - currentTime.Second, 1000 - currentTime.Millisecond);
            TimeSpan periodMinute = new TimeSpan(0, 0, 1, 0, 0);
            _updateMinuteTimer = new Timer(UpdateMinute, null, dueTimeMinute, periodMinute);

            // Seconds setup
            TimeSpan dueTimeSecond = new TimeSpan(0, 0, 0, 0, 1000 - currentTime.Millisecond);
            TimeSpan periodSecond = new TimeSpan(0, 0, 0, 1, 0);
            _updateSecondTimer = new Timer(UpdateSecond, null, dueTimeSecond, periodSecond);

            // go to sleep; time updates will happen automatically every minute
            Thread.Sleep(Timeout.Infinite);
        }

        static void UpdateMinute(object state)
        {
            Debug.Print("Minute start - " + DateTime.Now.ToLocalTime());
            Thread.Sleep(20000); // Sleep for 20 seconds - simulates UI animation
            Debug.Print("Minute end - " + DateTime.Now.ToLocalTime());
        }

        static void UpdateSecond(object state)
        {
            Debug.Print("Tick - " + DateTime.Now.ToLocalTime());
        }
    }
}
