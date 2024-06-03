using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal interface IEntityObject
    {
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}

