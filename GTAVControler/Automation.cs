using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using GTAVLogger;
using Vector3 = GTA.Math.Vector3;


namespace GTAVControler
{
    public class Automation
    {
        private static bool EnableAutoSaveScreenshot = false;
        private static bool Paused = false;
        private static long LastSaveTime = 0;
        private readonly static int SLEEP_TIME_WHEN_PAUSED = 3000;
        private readonly static long SAVE_TIME_GAP = 5000;

        private static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            long time = (long)ts.TotalMilliseconds;
            return time;
        }

        private static GTAVUtils.ImageInfo GetImageInfo(Bitmap screenshot)
        {
            Vector3 camPos = World.RenderingCamera.Position;
            Vector3 camRot = World.RenderingCamera.Rotation;
            return new GTAVUtils.ImageInfo(screenshot.Width, screenshot.Height, camPos, camRot);
        }


        private static GTAVUtils.ROI[] GetRoIs(GTAVUtils.ImageInfo imageInfo)
        {
            Vehicle[] vehicles = World.GetAllVehicles();
            List<GTAVUtils.ROI> rois = new List<GTAVUtils.ROI>();
            foreach (Vehicle vehicle in vehicles)
            {
                /*Logger.Log($"DisplayName - {vehicle.DisplayName}");
                Logger.Log($"HashCode - {vehicle.Model.GetHashCode()}");*/
                if (vehicle.IsOnScreen)
                {
                    GTAVUtils.ROI roi = new GTAVUtils.ROI(vehicle, vehicle.ClassType.ToString(), vehicle.Model.IsBigVehicle, rois.Count, imageInfo);
                    rois.Add(roi);
                }
            }
            return rois.ToArray();
        }

        public static void TriggerAutoSave()
        {
            EnableAutoSaveScreenshot = !EnableAutoSaveScreenshot;
        }

        public static void Prepare()
        {
            GTAVDataExporter.DataExporter.Prepare();
        }

        private static void SaveGTAVData()
        {
            Logger.Log("Run Automation.SaveGTAVData");

            string timestamp = GTAVUtils.Timer.GetTimeStamp();

            // screenshot
            Bitmap screenshot = GTAVUtils.Common.GetScreenshot();

            // imageInfo
            GTAVUtils.ImageInfo imageInfo = GetImageInfo(screenshot);

            // objects
            GTAVUtils.ROI[] rois = GetRoIs(imageInfo);

            // preprocess and save data
            GTAVUtils.Common.DataPreprocess(screenshot, rois, imageInfo).Save(timestamp, timestamp);

            LastSaveTime = GetTimeStamp();
        }

        public static void Pause()
        {
            Logger.Log("Run Automation.Pause");
            Paused = true;
            Game.Pause(true);
        }

        public static void Resume()
        {
            Logger.Log("Run Automation.Resume");
            Paused = false;
            Game.Pause(false);
        }

        public static void AutoSaveGTAVData()
        {
            if (!EnableAutoSaveScreenshot || Paused || GetTimeStamp() - LastSaveTime < SAVE_TIME_GAP) return;

            Pause();
            System.Threading.Thread.Sleep(SLEEP_TIME_WHEN_PAUSED);
            SaveGTAVData();
            Resume();
        }
    }
}
