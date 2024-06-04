using MysteryFoxes.Outpost.Items;
using ObservableCollections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MysteryFoxes.Outpost.Constructions
{


    internal class Construction : IEntity
    {
        bool done;

        private ObservableDictionary<ItemSO, (int Applied, int Need)> appliedItems = new();
        private readonly Guid guid;
        private readonly ConstructionSO data;

        public Construction(Guid guid, ConstructionSO data)
        {
            this.guid = guid;
            this.data = data;

            List<Pair<ItemSO, int>> price = data.Price;
            foreach (Pair<ItemSO, int> item in price)
                appliedItems.Add(item.Key, (0, item.Value));
        }
        public bool Done => done;
        public IObservableCollection<KeyValuePair<ItemSO, (int Applied, int Need)>> AppliedItems => appliedItems;
        public Guid Guid => guid;
        public ConstructionSO Data => data;

        public int Add(ItemSO item, int count = 1)
        {
            if (done) return count;

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
            done = appliedItems.All(x => x.Value.Applied >= x.Value.Need);
        }
    }
}
