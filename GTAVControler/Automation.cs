using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTA;

namespace GTAVControler
{
    public class Automation
    {
        private static GTAVUtils.ROI[] GetRoIs(int width, int height)
        {
            Vehicle[] vehicles = World.GetAllVehicles();
            List<GTAVUtils.ROI> rois = new List<GTAVUtils.ROI>();
            foreach (Vehicle vehicle in vehicles)
            {
                GTAVUtils.ROI roi = new GTAVUtils.ROI(vehicle, (GTAVUtils.ROI.DetectionType)vehicle.ClassType, rois.Count, width, height);
                if (roi.CheckVisible() || true)
                {
                    rois.Add(roi);
                }
            }
            return rois.ToArray();
        }

        public static void Prepare()
        {
            DataManager.GTAVManager.Prepare();
        }

        public static void SaveGTAVData()
        {
            string timestamp = GTAVUtils.Timer.GetTimeStamp();

            // screenshot
            Bitmap screenshot = GTAVUtils.Common.GetScreenshot();

            // roilabel
            GTAVUtils.ROI[] rois = GetRoIs(screenshot.Width, screenshot.Height);

            // preprocess and save data
            //GTAVUtils.Common.DataPreprocess(screenshot, rois).Save(timestamp, timestamp);
            new GTAVUtils.GTAVData(screenshot, rois).Save(timestamp, timestamp);
        }

        public static void Pause()
        {
            Game.Pause(true);
        }

        public static void Resume()
        {
            Game.Pause(false);
        }
    }
}
