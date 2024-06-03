using MysteryFoxes.Outpost.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Constructions
{
    internal abstract class ConstructionSO : EntitySO, IConstructionData
    {
        [SerializeField]
        List<Pair<ItemSO, int>> price;

        public List<Pair<ItemSO, int>> Price => price;
    }
}
