﻿using System;
using System.Drawing;
using System.IO;
using DataManager;
using Vector2 = GTA.Math.Vector2;
using Vector3 = GTA.Math.Vector3;
using Entity = GTA.Entity;

namespace GTAVUtils
{
    public class GTABoundingBox2
    {
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
        public bool IsValid { set; get; }
    }

    public class ROI
    {
        public ROI(Entity entity, DetectionType detectionType, int order, int originImageWidth, int originImageHeight)
        {
            RoIEntity = entity;
            Pos = new Vector3(entity.Position.X, entity.Position.Y, entity.Position.Z);
            BBox = GTAVData.ComputeBoundingBox(entity);
            Type = detectionType;
            Order = order;
            OriginImageWidth = originImageWidth;
            OriginImageHeight = originImageHeight;
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

        private Entity RoIEntity { get; }

        public Vector3 Pos { get; }

        public GTABoundingBox2 BBox { get; }

        public DetectionType Type { get; }

        public int OriginImageWidth { get; }

        public int OriginImageHeight { get; }

        public int Order { get;  }

        private int GetWidth(float w)
        {
            return (int)(w * OriginImageWidth);
        }
        private int GetHeight(float h)
        {
            return (int)(h * OriginImageHeight);
        }

        public bool CheckVisible()
        {
            return HashFunctions.CheckVisible(RoIEntity);
        }

        public string Serialize(bool autoCrlf = false)
        {
            string data = $"{Order},{GetWidth(BBox.Min.X)},{GetHeight(BBox.Min.Y)},{GetWidth(BBox.Max.X)},{GetHeight(BBox.Max.Y)},{Type}";
            if (!autoCrlf)
            {
                return data;
            }
            return $"{data}\n";
        }

        public void Draw(Bitmap image)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = Graphics.FromImage(image);
            g.DrawRectangle(pen, GetWidth(BBox.Min.X), GetHeight(BBox.Min.Y), GetWidth(BBox.Width), GetHeight(BBox.Height));
            g.DrawString($"{Order}", SystemFonts.DefaultFont, Brushes.Red, GetWidth(BBox.Min.X), GetHeight(BBox.Max.Y));
        }
    }

    public class GTAVData
    {
        public GTAVData(Bitmap image, ROI[] rois)
        {
            Version = "v0.0.1";
            Image = image;
            RoIs = rois;
        }

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
                        IsValid = false
                    };
                }

                res = new GTABoundingBox2
                {
                    Min = new Vector2(Math.Min(res.Min.X, position.X), Math.Min(res.Min.Y, position.Y)),
                    Max = new Vector2(Math.Max(res.Max.X, position.X), Math.Max(res.Max.Y, position.Y)),
                    IsValid = true
                };
            }

            if (res.Max.X == res.Min.X || res.Max.Y == res.Min.Y)
            {
                res.IsValid = false;
            }

            return res;
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

        public void Save(string imageName, string labelName, bool drawBBox = true)
        {
            GTAVManager.SaveImage(imageName, Image);

            string txt = $"{Image.Width},{Image.Height}\n";
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