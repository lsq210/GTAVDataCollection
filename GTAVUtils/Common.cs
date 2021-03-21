using System.IO;
using System.Drawing;
using System.Windows.Forms;

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
    }
}
