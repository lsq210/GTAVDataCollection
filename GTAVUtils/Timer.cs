using System;
using System.Timers;

namespace GTAVUtils
{
    public class Timer
    {
        public delegate void TimerFunc(object sender, ElapsedEventArgs e);

        public static void SetTimeout(TimerFunc func, int timeout, bool autoReset = false)
        {
            System.Timers.Timer t = new System.Timers.Timer(timeout);
            t.Elapsed += new ElapsedEventHandler(func);
            t.AutoReset = autoReset;
            t.Enabled = true;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
