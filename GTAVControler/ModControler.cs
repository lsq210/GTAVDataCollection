using System;
using System.Windows.Forms;
using GTA;
using GTAVLogger;
using GTAVDataGenerator;
using GTAVConfigManager;

namespace GTAVControler
{
    class Cotroler: Script
    {
        private readonly string MAIN_DLL_FILE_PATH = "./scripts/GTAVControler.dll";

        public Cotroler()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            ConfigManager.LoadConfig(MAIN_DLL_FILE_PATH);
            Automation.Prepare();
            DataGenerator.InitModel();
        }

        private void OnTick(object sender, EventArgs e)
        {
            Automation.AutoSaveGTAVData();
            Logger.Print();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // 唤起控制台开关
            if (e.KeyCode == Keys.C)
            {
                Logger.Trigger();
            }

            // 添加随机载具
            if (e.KeyCode == Keys.N)
            {
                DataGenerator.AddVehicle();
            }

            // 截图开关
            if (e.KeyCode == Keys.Y)
            {
                Automation.TriggerAutoSave();
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
