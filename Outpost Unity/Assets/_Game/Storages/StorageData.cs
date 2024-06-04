using MysteryFoxes.Outpost.Items;
using System;
using UnityEngine;

namespace MysteryFoxes.Outpost.Storages
{
    [Serializable]
    internal class StorageData : IEntityData
    {
        [SerializeField]
        ItemSO[] storable;

        [SerializeField]
        UpgradeData<int> capacity;

        public ItemSO[] Storable => storable;
        public UpgradeData<int> Capacity => capacity;
    }
}