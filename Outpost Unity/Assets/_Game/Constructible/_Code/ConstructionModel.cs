using MysteryFoxes.Outpost.Items;
using ObservableCollections;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MysteryFoxes.Outpost.Constructions
{
    internal class ConstructionModel
    {
        ReactiveProperty<bool> done = new();

        private ObservableDictionary<ItemSO, (int Applied, int Need)> appliedItems = new();
        private readonly Guid guid;
        private readonly ConstructionConfig data;

        public ConstructionModel(Guid guid, ConstructionConfig data)
        {
            this.guid = guid;
            this.data = data;

            List<Pair<ItemSO, int>> price = data.Price;
            foreach (Pair<ItemSO, int> item in price)
                appliedItems.Add(item.Key, (0, item.Value));
        }
        public ReadOnlyReactiveProperty<bool> Done => done;
        public IObservableCollection<KeyValuePair<ItemSO, (int Applied, int Need)>> AppliedItems => appliedItems;
        public Guid Guid => guid;
        public ConstructionConfig Data => data;

        public int Add(ItemSO item, int count = 1)
        {
            if (done.CurrentValue) return count;

            if (count <= 0 || !appliedItems.ContainsKey(item))
                return count;

            (int Applied, int Need) = appliedItems[item];

            Applied += count;

            int remain = 0;

            if (Applied > Need)
                remain = Applied - Need;

            appliedItems[item] = (Applied, Need);

            CheckIfDone();

            return remain;
        }

        void CheckIfDone()
        {
            done.Value = appliedItems.All(x => x.Value.Applied >= x.Value.Need);
        }
    }
}
