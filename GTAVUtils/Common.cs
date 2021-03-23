using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GTAVUtils
{
    public class Common
    {
        public static Bitmap GetScreenshot()
        {
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(screenshot);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            g.Dispose();
            return screenshot;
        }
        
        public static ROI[] FilterRoIs(ROI[] rois)
        {
            // TODO: @lsq210
            return rois;
            List<ROI> filteredRoIs = new List<ROI>();
            foreach (ROI roi in rois)
            {
                roi.BBox.Min = new GTA.Math.Vector2(roi.BBox.Min.X - .1f, roi.BBox.Min.Y - .1f);
                roi.BBox.Max = new GTA.Math.Vector2(roi.BBox.Max.X - .1f, roi.BBox.Max.Y - .1f);

                if (roi.BBox.Min.X > 0 && roi.BBox.Min.Y > 0 && roi.BBox.Max.X > 0 && roi.BBox.Max.X > 0)
                {
                    filteredRoIs.Add(roi);
                }
            }
            return filteredRoIs.ToArray();
        }

        public static Bitmap CutScreenshot(Bitmap screenshot)
        {
            // TODO: @lsq210
            Bitmap cutedScreenshot = screenshot;
            return cutedScreenshot;
        }
    }
}
