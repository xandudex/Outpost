using Unity.Mathematics;
using UnityEngine;

namespace MysteryFoxes.Outpost.Runner
{
    internal static class Extensions
    {
        public static Vector3 ToVector(this float3 f3)=> new Vector3(f3.x, f3.y, f3.z);
    }
}
