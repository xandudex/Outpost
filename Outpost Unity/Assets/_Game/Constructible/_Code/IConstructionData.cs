using MysteryFoxes.Outpost.Items;
using System.Collections.Generic;

namespace MysteryFoxes.Outpost.Constructions
{
    internal interface IConstructionData : IEntityData
    {
        public List<Pair<ItemSO, int>> Price { get; }
    }
}
