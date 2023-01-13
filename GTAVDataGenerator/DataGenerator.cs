using GTA;
using GTA.Math;
using GTAVLogger;
using Vector2 = GTA.Math.Vector2;
using Vector3 = GTA.Math.Vector3;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using SharpDX;

namespace GTAVDataGenerator
{
    public class DataGeneratorItem
    {
        public DataGeneratorItem(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }
        public readonly Vehicle Vehicle;
    }

    public class DataGenerator
    {
        public static readonly List<DataGeneratorItem> Items = new List<DataGeneratorItem>();
        private static readonly string[] VehicleHashes = File.ReadAllLines("vehiclehash.txt", Encoding.UTF8);

        public static void InitModel()
        {
            foreach(string line in VehicleHashes)
            {
                Model model= new Model(int.Parse(line.Split('\t')[1]));
                model.Request();
            }
        }
        private static Vector3 GetNextPosition()
        {
            Vector3 cameraPoistion = World.RenderingCamera.Position;
            Random rand = new Random();
            /*var num = rand.Next(0, 100) - 50;*/
            var num = 0;
            var position = new Vector3(cameraPoistion.X + num, cameraPoistion.Y + num, 0);
            return position;
        }

        private static float GetNextHeading()
        {
            return new Random().Next(0, 360) - 180;
        }

        private static Model GetNextModel()
        {
            Random rand = new Random();
            int tempIndex = rand.Next(0, VehicleHashes.Length - 1);
            string selectedVehicleHash = VehicleHashes[tempIndex].Split('\t')[1];
            return new Model(int.Parse(selectedVehicleHash));
        }

        private static bool CheckVehicleCollided(Model model, Vector3 position, double heading)
        {
            bool vehicleCollided = false;
            (Vector3 amin, Vector3 amax) = model.Dimensions;
            heading = Math.PI / 180 * heading;
            var bbox = new BoundingBox(new SharpDX.Vector3(amin.X, amin.Y, amin.Z), new SharpDX.Vector3(amax.X, amax.Y, amax.Z));
            Vector2 Min = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
            Vector2 Max = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
            foreach (var corner in bbox.GetCorners())
            {
                float pointX = (float)(position.X + Math.Cos(heading) * corner.X - Math.Sin(heading) * corner.Y);
                float pointY = (float)(position.Y + Math.Cos(heading) * corner.Y + Math.Sin(heading) * corner.X);
                Min = new Vector2(Math.Min(Min.X, pointX), Math.Min(Min.Y, pointY));
                Max = new Vector2(Math.Max(Max.X, pointX), Math.Max(Max.Y, pointY));
            }
            Logger.Log($"min,max:{Min},{Max}");
            Vehicle[] vehicles = World.GetAllVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.IsOnScreen)
                {
                    (Vector3 bmin, Vector3 bmax) = vehicle.Model.Dimensions;
                    bmin = vehicle.GetOffsetPosition(bmin);
                    bmax = vehicle.GetOffsetPosition(bmax);
                    if (Min.X < bmax.X && Min.Y < bmax.Y && Max.X > bmin.X && Max.Y > bmin.Y)
                    {
                        vehicleCollided = true;
                    }
                }
            }
            return vehicleCollided;
        }

        public static void AddVehicle()
        {
            Vector3 position = GetNextPosition();
            Model model = GetNextModel();
            float heading = GetNextHeading();
            model.Request();
            model.RequestCollision();
            Vehicle vehicle = null;
            Logger.Log($"position,{position}");
            Logger.Log($"dimension,{model.Dimensions}");
            Logger.Log($"heading,{heading}");
            Logger.Log($"collided,{CheckVehicleCollided(model, position, heading)}");
            if (CheckVehicleCollided(model, position, heading))
            {
                Logger.Warning("vehicle will be collide");
            }
            else
            {
                vehicle = World.CreateVehicle(model, position, heading);
            }
            if (vehicle == null)
            {
                Logger.Warning("vehicle is null");
            }
            else
            {
                vehicle.IsPersistent = true;
                vehicle.PlaceOnGround();
                //mod.MarkAsNoLongerNeeded();
                Items.Add(new DataGeneratorItem(vehicle));
                /*Logger.Log($"vehicle - {vehicle.ClassType}is added on {position}");*/
            }
        }
    }
}
