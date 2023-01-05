using GTA;
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
            Function.Call<bool>(Hash.GET_SCREEN_COORD_FROM_WORLD_COORD, pos.X, pos.Y, pos.Z, resX, resY);
            return new Vector2(resX.GetResult<float>(), resY.GetResult<float>());
        }
    }
}
