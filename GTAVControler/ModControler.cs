using System;
using System.Windows.Forms;
using GTA;

namespace GTAVControler
{
    class Cotroler: Script
    {
        private bool enableAutoSaveScreenshot = false;

        public Cotroler()
        {
            Tick += OnTick;
            Interval = 4000;
            KeyDown += OnKeyDown;
            Automation.Prepare();
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (this.enableAutoSaveScreenshot)
            {
                Automation.Pause();
                System.Threading.Thread.Sleep(2000);
                Automation.SaveGTAVData();
                Automation.Resume();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Y)
            {
                this.enableAutoSaveScreenshot = !this.enableAutoSaveScreenshot;
            }

            if (e.KeyCode == Keys.U)
            {
                Automation.Pause();
            }

            if (e.KeyCode == Keys.I)
            {
                Automation.Resume();
            }
        }
    }
}
