using System;
using System.Drawing;
using System.IO;
using DataManager;
using Vector2 = GTA.Math.Vector2;
using Vector3 = GTA.Math.Vector3;
using Entity = GTA.Entity;
using GTA;

namespace GTAVUtils
{
    public class GTABoundingBox2
    {
        public enum DataQuality
        {
            High = 1,
            Middle = 2,
            Low = 3
        }
        public Vector2 Min { get; set; }
        public Vector2 Max { get; set; }
        public float Area
        {
            get
            {
                return (Max.X - Min.X) * (Max.Y - Min.Y);
            }
        }

        public float Width
        {
            get
            {
                return Max.X - Min.X;
            }
        }

        public float Height
        {
            get
            {
                return Max.Y - Min.Y;
            }
        }
        public bool IsValid {
            get
            {
                //return true;
                return Quality == DataQuality.High;
            }
        }

        public DataQuality Quality { set; get; }

        public static GTABoundingBox2 ComputeBoundingBox(Entity entity)
        {
            var m = entity.Model;
            (Vector3 gmin, Vector3 gmax) = m.Dimensions;

            var bbox = new SharpDX.BoundingBox(new SharpDX.Vector3(gmin.X, gmin.Y, gmin.Z), new SharpDX.Vector3(gmax.X, gmax.Y, gmax.Z));

            var res = new GTABoundingBox2
            {
                Min = new Vector2(float.PositiveInfinity, float.PositiveInfinity),
                Max = new Vector2(float.NegativeInfinity, float.NegativeInfinity)
            };

            foreach (var corner in bbox.GetCorners())
            {
                var cornerVector = new Vector3(corner.X, corner.Y, corner.Z);

                cornerVector = entity.GetOffsetPosition(cornerVector);
                Vector2 position = HashFunctions.Convert3dTo2d(cornerVector);

                if (position.X == .1f || position.Y == .1f || position.X == .9f || position.Y == .9f)
                {
                    return new GTABoundingBox2
                    {
                        Min = new Vector2(float.PositiveInfinity, float.PositiveInfinity),
                        Max = new Vector2(float.NegativeInfinity, float.NegativeInfinity),
                        Quality = DataQuality.Low
                    };
                }

                res = new GTABoundingBox2
                {
                    Min = new Vector2(Math.Min(res.Min.X, position.X), Math.Min(res.Min.Y, position.Y)),
                    Max = new Vector2(Math.Max(res.Max.X, position.X), Math.Max(res.Max.Y, position.Y)),
                    Quality = DataQuality.High
                };
            }

            if (res.Max.X == res.Min.X || res.Max.Y == res.Min.Y)
            {
                res.Quality = DataQuality.Low;
            }

            return res;
        }
    }

    public class ROI
    {
        public ROI(Entity entity, DetectionType detectionType, bool isBigVehicle, int order, ImageInfo imageInfo)
        {
            RoIEntity = entity;
            Pos = new Vector3(entity.Position.X, entity.Position.Y, entity.Position.Z);
            BBox = GTABoundingBox2.ComputeBoundingBox(entity);
            if (!CheckVisible()) {
                BBox.Quality = GTABoundingBox2.DataQuality.Middle;
            }
            Type = detectionType;
            IsBigVehicle = isBigVehicle;
            Order = order;
            ImageInfo = imageInfo;
        }

        public ROI(ROI preROI)
        {
            RoIEntity = preROI.RoIEntity;
            Pos = preROI.Pos;
            BBox = preROI.BBox;
            Type = preROI.Type;
            IsBigVehicle = preROI.IsBigVehicle;
            Order = preROI.Order;
            ImageInfo = preROI.ImageInfo;
        }

        public enum DetectionType
        {
            Compacts = 0,
            Sedans = 1,
            SUVs = 2,
            Coupes = 3,
            Muscle = 4,
            SportsClassics = 5,
            Sports = 6,
            Super = 7,
            Motorcycles = 8,
            OffRoad = 9,
            Industrial = 10,
            Utility = 11,
            Vans = 12,
            Cycles = 13,
            Boats = 14,
            Helicopters = 15,
            Planes = 16,
            Service = 17,
            Emergency = 18,
            Military = 19,
            Commercial = 20,
            Trains = 21,
            OpenWheel = 22
        }

        public Entity RoIEntity { get; }

        public Vector3 Pos { get; }

        public GTABoundingBox2 BBox { get; }

        public DetectionType Type { get; }

        public bool IsBigVehicle { get; }

        public int Order { get; }

        public ImageInfo ImageInfo { get; }

        // FIXME:
        private int GetWidth(float w)
        {
            return (int)(w * ImageInfo.Width);
        }
        private int GetHeight(float h)
        {
            return (int)(h * ImageInfo.Height);
        }
        public bool CheckVisible()
        {
            Vector3 cameraPos = World.RenderingCamera.Position;
            Vector3 sourcePos = new Vector3(cameraPos.X, cameraPos.Y, cameraPos.Z - 0.5f) + World.RenderingCamera.ForwardVector.Normalized;
            Vector3 targetPos = RoIEntity.Position;
            var res = World.Raycast(sourcePos, targetPos, IntersectFlags.Everything, null);
            return !res.DidHit;
        }

        public string Serialize(bool autoCrlf = false)
        {
            string vehicleSize = IsBigVehicle ? "large-vehicle" : "small-vehicle";
            string data = $"{Order},{GetWidth(BBox.Min.X)},{GetHeight(BBox.Min.Y)},{GetWidth(BBox.Max.X)},{GetHeight(BBox.Max.Y)},{Type},{vehicleSize},{BBox.Quality}";
            if (!autoCrlf)
            {
                return data;
            }
            return $"{data}\n";
        }

        public void Draw(Bitmap image)
        {

            Color color = Color.Black;
            //switch (BBox.Quality)
            //{
            //    case GTABoundingBox2.DataQuality.High:
            //        color = Color.Green;
            //        break;
            //    case GTABoundingBox2.DataQuality.Middle:
            //        color = Color.Yellow;
            //        break;
            //    case GTABoundingBox2.DataQuality.Low:
            //        color = Color.Red;
            //        break;
            //}
            if (IsBigVehicle)
            {
                color = Color.Green;
            }
            else
            {
                color = Color.Red;
            }
            Pen pen = new Pen(color);
            Graphics g = Graphics.FromImage(image);
            g.DrawRectangle(pen, GetWidth(BBox.Min.X), GetHeight(BBox.Min.Y), GetWidth(BBox.Width), GetHeight(BBox.Height));
            g.DrawString($"{Order}:{Type}", SystemFonts.DefaultFont, new SolidBrush(color), GetWidth(BBox.Min.X), GetHeight(BBox.Max.Y));
        }
    }

    public class ImageInfo
    {
        public ImageInfo(int width, int height, Vector3 camPos, Vector3 camRot)
        {
            Width = width;
            Height = height;
            CamPos = camPos;
            CamRot = camRot;
        }

        public ImageInfo(ImageInfo preImageInfo)
        {
            Width = preImageInfo.Width;
            Height = preImageInfo.Height;
            CamPos = preImageInfo.CamPos;
            CamRot = preImageInfo.CamRot;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public Vector3 CamPos { get; }

        public Vector3 CamRot { get; }
    }

    public class GTAVData
    {
        public GTAVData(Bitmap image, ROI[] rois, ImageInfo imageInfo)
        {
            Version = "v0.0.1";
            Image = image;
            RoIs = rois;
            ImageInfo = imageInfo;
        }

        public string Version { get; set; }

        public Bitmap Image { get; set; }

        public int ImageWidth { 
            get {
                return Image.Width;
            }
        }

        public int ImageHight
        {
            get
            {
                return Image.Height;
            }
        }

        public ROI[] RoIs;
        public ImageInfo ImageInfo;

        public void Save(string imageName, string labelName, bool drawBBox = true)
        {
            GTAVManager.SaveImage(imageName, Image);
            string imageSize = $"{Image.Width},{Image.Height}";
            string camInfo = $"{ImageInfo.CamPos},{ImageInfo.CamRot}";
            string txt = $"{imageSize}\n{camInfo}\n";
            for (int i = 0; i < RoIs.Length; i++)
            {
                txt += RoIs[i].Serialize(true);
            }
            GTAVManager.SaveTxt(labelName, txt);

            if (drawBBox)
            {
                Draw();
                GTAVManager.SaveImage($"bbox/{Path.GetFileNameWithoutExtension(imageName)}", Image);
            }

            GTAVManager.Commit();
        }

        public void Draw()
        {
            foreach(ROI r in RoIs)
            {
                r.Draw(Image);
            }
        }
    }
}
