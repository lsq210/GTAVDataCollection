using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GTAVUtils
{
    class Timer
    {
        public void setTimeout(String functionName, int timeout, bool autoReset = false)
        {
            System.Timers.Timer t = new System.Timers.Timer(timeout);//实例化Timer类，设置间隔时间为10000毫秒； 
            t.Elapsed += new System.Timers.ElapsedEventHandler(timeup);//到达时间的时候执行事件； 
            t.AutoReset = autoReset;//设置是执行一次（false）还是一直执行(true)； 
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }
    }
}
