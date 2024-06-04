using MysteryFoxes.Outpost.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Constructions
{
    internal interface IConstructionData : IEntityData
    {
        public GameObject Prefab { get; }
        public List<Pair<ItemSO, int>> Price { get; }
    }
}
