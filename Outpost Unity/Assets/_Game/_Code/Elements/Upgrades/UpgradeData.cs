using MysteryFoxes.Outpost.Items;
using System;
using System.Linq;
using UnityEngine;

namespace MysteryFoxes.Outpost
{
    [Serializable]
    internal class UpgradeData<T>
    {
        [SerializeField]
        T[] values;

        [SerializeField]
        Pair<ItemSO, int>[] cost;

        public T[] Values => values.ToArray();
        public Pair<ItemSO, int>[] Cost => cost.ToArray();
    }
}
