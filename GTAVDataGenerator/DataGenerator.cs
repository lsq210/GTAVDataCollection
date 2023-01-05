using GTA;
using GTA.Math;
using GTAVLogger;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace GTAVDataGenerator
{
    public class DataGeneratorItem
    {
        public DataGeneratorItem(Vehicle vehicle, Vector3 position)
        {
            this.Vehicle = vehicle;
            this.Position = position;
        }
        public readonly Vehicle Vehicle;
        public readonly Vector3 Position;
    }

    public class DataGenerator
    {
        public static readonly List<DataGeneratorItem> Items = new List<DataGeneratorItem>();

        private static Vector3 GetNextPlacePosition()
        {
            Vector3 cameraPoistion = World.RenderingCamera.Position;
            Random rand = new Random();
            var num = rand.Next(0, 100) - 50;
            var position = new Vector3(cameraPoistion.X + num, cameraPoistion.Y + num, 0);
            return position;
        }

        private static Model GetNextModel()
        {
            string vehicleHashPath = "vehiclehash.txt";
            string[] vehicleHashes = File.ReadAllLines(vehicleHashPath, Encoding.UTF8);
            Random rand = new Random();
            int tempIndex = rand.Next(0, vehicleHashes.Length - 1);
            string selectedVehicleHash = vehicleHashes[tempIndex].Split('\t')[1];
            return new Model(int.Parse(selectedVehicleHash));
        }

        public static void AddVehicle()
        {
            Vector3 position = GetNextPlacePosition();
            Model model = GetNextModel();

            model.Request();
            Vehicle vehicle = World.CreateVehicle(model, position);
            
            if (vehicle == null)
            {
                Logger.Warning("vehicle is null");
            }
            else
            {
                vehicle.IsPersistent = true;
                vehicle.PlaceOnGround();
                //mod.MarkAsNoLongerNeeded();
                Items.Add(new DataGeneratorItem(vehicle, position));
                Logger.Log($"vehicle - {vehicle.ClassType}is added on {position}");
            }
        }
    }
}
