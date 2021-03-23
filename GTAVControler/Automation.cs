using System.Collections.Generic;
using System.Drawing;
using GTA;
using GTA.Math;

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
                if (roi.BBox.IsValid && roi.CheckVisible(vehicle))
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

            // label
            GTAVUtils.ROI[] labels = GetRoIs(screenshot.Width, screenshot.Height);

            // save data
            new GTAVUtils.GTAVData(GTAVUtils.Common.CutScreenshot(screenshot), GTAVUtils.Common.FilterRoIs(labels)).Save(timestamp, timestamp);
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
