﻿using GTA;
using GTA.Math;
using GTA.Native;

namespace GTAVUtils
{
    public class HashFunctions
    {
        public static Vector2 Convert3dTo2d(Vector3 pos)
        {
            OutputArgument resX = new OutputArgument();
            OutputArgument resY = new OutputArgument();
            Function.Call<bool>(Hash._GET_SCREEN_COORD_FROM_WORLD_COORD, pos.X, pos.Y, pos.Z, resX, resY);
            return new Vector2(resX.GetResult<float>(), resY.GetResult<float>());
        }

        public static bool CheckVisible(Entity entity)
        {
            return true;
            // Camera camera = World.RenderingCamera;
            // Model m = new Model(VehicleHash.Airbus);
            // Vehicle cameraVehicle = World.CreateVehicle(m, camera.Position);
            // return Function.Call<bool>((Hash)0x0267D00AF114F17A, cameraVehicle, entity);
        }
    }
}