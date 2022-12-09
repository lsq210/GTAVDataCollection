using System.Drawing;
using System.IO;

namespace GTAVDataExporter
{
    public class DataExporter
    {
        public static void Prepare()
        {
            FileMamager.Prepare();
        }

        public static void SaveImage(string fileName, Bitmap image)
        {
            FileMamager.SaveImage(fileName, image);
        }

        public static void SaveTxt(string fileName, string txt)
        {
            FileMamager.SaveTxt(fileName, txt);
        }

        public static void SaveBBox(string fileName, Bitmap image)
        {
            FileMamager.SaveBBox(fileName, image);
        }

        public static void Commit()
        {
            FileMamager.Commit();
        }
    }
}
