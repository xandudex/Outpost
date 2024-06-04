using MysteryFoxes.Outpost.Items;
using R3;
using System.Collections.Generic;
using System.Linq;

namespace MysteryFoxes.Outpost.Storages
{

    internal class StorageModel : IEntity
    {
        ReactiveCommand<IReadOnlyDictionary<ItemSO, int>> storageChanged = new();
        ItemSO[] storable;
        Upgrade<int> capacity;
        Dictionary<ItemSO, int> current = new();
        ReactiveProperty<int> count = new();
        StorageData data;
        public StorageModel(StorageData data, ItemSO[] storable, Upgrade<int> capacity, Dictionary<ItemSO, int> initial = null)
        {
            this.data = data;
            this.storable = storable;
            this.capacity = capacity;

            foreach (var item in storable)
            {
                int value = initial != null && initial.ContainsKey(item) ? initial[item] : 0;
                current.Add(item, value);
            }

            CacheCount(current);

            storageChanged.Subscribe(CacheCount);
        }

        public Observable<IReadOnlyDictionary<ItemSO, int>> StorageChanged => storageChanged;
        public StorageData Data => data;
        public ReadOnlyReactiveProperty<int> Count => count;
        public ItemSO[] Storable => storable;
        public Upgrade<int> Capacity => capacity;
        public IReadOnlyDictionary<ItemSO, int> Current => current;

        private void CacheCount(IReadOnlyDictionary<ItemSO, int> dict) => count.Value = dict.Sum(x => x.Value);

        public void Add(ItemSO item, int count = 1)
        {
            if (count <= 0 || !current.ContainsKey(item) || count + this.count.Value > Capacity)
                return;

            current[item] += count;

            storageChanged.Execute(current);
        }
    }
}