using System.Drawing;
using System.IO;

namespace GTAVDataExporter
{
    class FileMamager
    {
        private static readonly string DataFolder = "data";
        private static readonly string ImageSubFolder = "images";
        private static readonly string RoISubFolder = "labels";

        private static string GetImagePath(string fileName)
        {
            return $"{DataFolder}/{ImageSubFolder}/{fileName}.jpg";
        }

        private static string GetLabelPath(string fileName)
        {
            return $"{DataFolder}/{RoISubFolder}/{fileName}.txt";
        }

        private static string GetDataPath()
        {
            return $"{DataFolder}/";
        }

        public static void Prepare()
        {
            FileMamager.CreateFileDirectoryIfNotExist(GetDataPath());
        }

        public static void CreateFileDirectoryIfNotExist(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        }
        public static void SaveImage(string fileName, Bitmap image)
        {
            CreateFileDirectoryIfNotExist(GetImagePath(fileName));
            image.Save(GetImagePath(fileName));
        }

        public static void SaveTxt(string fileName, string txt)
        {
            CreateFileDirectoryIfNotExist(GetLabelPath(fileName));
            using (StreamWriter sw = new StreamWriter(GetLabelPath(fileName)))
            {
                sw.Write(txt);
            }
        }

        public static void Commit() { }
    }
}
