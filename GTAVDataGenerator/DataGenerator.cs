using GTA;
using GTA.Math;
using GTAVLogger;
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
            var playerPosition = Game.Player.Character.Position;
            var position = new Vector3(playerPosition.X + 2f, playerPosition.Y + 2f, playerPosition.Z);
            return position;
        }

        private static Model GetNextModel()
        {
            return new Model(VehicleHash.Vacca);
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
                Logger.Log($"vehicle - {vehicle.ClassType} added");
            }
        }
    }
}
