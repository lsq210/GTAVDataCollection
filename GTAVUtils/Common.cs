using System;
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

        public static GTAVData DataPreprocess(Bitmap screenshot, ROI[] RoIs)
        {
            // cutImage
            int cutWidth = (int)(screenshot.Width * 0.1);
            int cutHeight = (int)(screenshot.Height * 0.1);
            Rectangle rect = new Rectangle(cutWidth, cutHeight, screenshot.Width - 2 * cutWidth, screenshot.Height - 2 * cutHeight);
            Bitmap cutedScreenshot = screenshot.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);

            // filterRoIs
            List<ROI> filteredRoIs = new List<ROI>();
            foreach (ROI roi in RoIs)
            {
                ROI filteredRoI = new ROI(roi)
                {
                    ImageWidth = cutedScreenshot.Width,
                    ImageHeight = cutedScreenshot.Height
                };
                float ratio = roi.ImageWidth / filteredRoI.ImageWidth;
                if(roi.BBox.Quality != GTABoundingBox2.DataQuality.Low)
                {
                    if (roi.BBox.Min.X > 0.1 && roi.BBox.Min.Y > 0.1)
                    {
                        if (roi.BBox.Max.X < 0.9 && roi.BBox.Max.Y < 0.9)
                        {
                            filteredRoI.BBox.Min = new GTA.Math.Vector2((roi.BBox.Min.X - .1f) * ratio, (roi.BBox.Min.Y - .1f) * ratio);
                            filteredRoI.BBox.Max = new GTA.Math.Vector2((roi.BBox.Max.X - .1f) * ratio, (roi.BBox.Max.Y - .1f) * ratio);
                            filteredRoIs.Add(filteredRoI);
                        }
                    }
                }
            }
            return new GTAVData(cutedScreenshot, filteredRoIs.ToArray());
        }
    }
}
