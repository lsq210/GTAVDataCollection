using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GTA.Math;
using GTAVLogger;

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

        public static GTAVData DataPreprocess(Bitmap screenshot, ROI[] RoIs, ImageInfo imageInfo)
        {
            Logger.Log($"Run Common.DataPreprocess, ROI Count: {RoIs.Length}, imageWith: {imageInfo.Width}, imageHeight: {imageInfo.Height}");

            float cutBorderWidth = .1f;

            // cutImage
            int cutWidth = (int)(screenshot.Width * cutBorderWidth);
            int cutHeight = (int)(screenshot.Height * cutBorderWidth);
            Rectangle rect = new Rectangle(cutWidth, cutHeight, screenshot.Width - 2 * cutWidth, screenshot.Height - 2 * cutHeight);
            Bitmap cutedScreenshot = screenshot.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
            ImageInfo cutedImageInfo = new ImageInfo(imageInfo)
            {
                Width = cutedScreenshot.Width,
                Height = cutedScreenshot.Height
            };

            // filterRoIs
            List<ROI> filteredRoIs = new List<ROI>();
            foreach (ROI roi in RoIs)
            {
                ROI filteredRoI = new ROI(roi)
                {
                    ImageInfo = cutedImageInfo
                };
                float ratio = imageInfo.Width / (float)cutedImageInfo.Width;
                if (roi.BBox.Quality != GTABoundingBox2.DataQuality.Low)
                {
                    if (roi.BBox.Min.X > cutBorderWidth && roi.BBox.Min.Y > cutBorderWidth)
                    {
                        if (roi.BBox.Max.X < (1 - cutBorderWidth) && roi.BBox.Max.Y < (1 - cutBorderWidth))
                        {
                            filteredRoI.BBox.Min = new Vector2((roi.BBox.Min.X - cutBorderWidth) * ratio, (roi.BBox.Min.Y - cutBorderWidth) * ratio);
                            filteredRoI.BBox.Max = new Vector2((roi.BBox.Max.X - cutBorderWidth) * ratio, (roi.BBox.Max.Y - cutBorderWidth) * ratio);
                            filteredRoIs.Add(filteredRoI);
                        }
                    }
                }
            }
            Logger.Log($"End Common.DataPreprocess, Filtered ROI Count: {filteredRoIs.Count}, imageWith: {cutedImageInfo.Width}, imageHeight: {cutedImageInfo.Height}");
            return new GTAVData(cutedScreenshot, filteredRoIs.ToArray(), cutedImageInfo);
        }
    }
}
