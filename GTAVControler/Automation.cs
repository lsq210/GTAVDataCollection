using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using Vector3 = GTA.Math.Vector3;


namespace GTAVControler
{
    public class Automation
    {
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
                GTAVUtils.ROI roi = new GTAVUtils.ROI(vehicle, vehicle.ClassType.ToString(), vehicle.Model.IsBigVehicle, rois.Count, imageInfo);
                rois.Add(roi);
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

            // imageInfo
            GTAVUtils.ImageInfo imageInfo = GetImageInfo(screenshot);

            // objects
            GTAVUtils.ROI[] rois = GetRoIs(imageInfo);

            // preprocess and save data
            GTAVUtils.Common.DataPreprocess(screenshot, rois, imageInfo).Save(timestamp, timestamp);
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
