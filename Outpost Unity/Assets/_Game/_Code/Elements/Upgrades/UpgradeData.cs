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
        Pair<Item, int>[] cost;

        public T[] Values => values.ToArray();
        public Pair<Item, int>[] Cost => cost.ToArray();
    }
}
