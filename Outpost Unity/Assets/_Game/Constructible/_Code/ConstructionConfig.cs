using MysteryFoxes.Outpost.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Constructions
{
    internal abstract class ConstructionConfig : EntityConfig, IConstructionData
    {
        [SerializeField]
        GameObject constructionPrefab;

        [SerializeField]
        List<Pair<ItemSO, int>> price;

        public List<Pair<ItemSO, int>> Price => price;
        GameObject IConstructionData.Prefab => constructionPrefab;
    }
}
