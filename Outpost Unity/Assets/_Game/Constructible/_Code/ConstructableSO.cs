using MysteryFoxes.Outpost.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal abstract class ConstructableSO : EntitySO
    {
        [SerializeField]
        List<Pair<ItemSO, int>> price;

        public List<Pair<ItemSO, int>> Price => price;
    }
}
