using System;
using System.IO;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace GTAVControler
{
    class Cotroler: Script
    {
        public Cotroler()
        {
            Tick += OnTick; //刷新事件
            KeyDown += OnKeyDown; //按键按下事件
            Interval = 10; //刷新事件的间隔时间，单位毫秒
        }

        //刷新事件
        void OnTick(object sender, EventArgs e)
        {
            //本例中不需要使用到该事件，实际如果需要刷新事件，则在刷新事件需要处理的内容写在这里
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.T)
            {
                
            }
        }
}
