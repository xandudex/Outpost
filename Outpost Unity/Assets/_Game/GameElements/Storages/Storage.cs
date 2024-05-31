using MysteryFoxes.Outpost.Items;
using ObservableCollections;
using R3;
using System.Linq;

namespace MysteryFoxes.Outpost.Storages
{

    internal class Storage
    {
        ItemSO[] storable;
        Upgrade<int> capacity;
        ObservableList<Pair<Item, int>> current = new();
        ReactiveProperty<int> count = new();
        public Storage(ItemSO[] storable, Upgrade<int> capacity, Pair<Item, int>[] initial = null)
        {
            this.storable = storable;
            this.capacity = capacity;

            current.CollectionChanged += CacheCount;

            if (initial != null)
                current.AddRange(initial);
        }

        public ReadOnlyReactiveProperty<int> Count => count;
        public ItemSO[] Storable => storable;
        public Upgrade<int> Capacity => capacity;
        public IObservableCollection<Pair<Item, int>> Current => current;

        private void CacheCount(in NotifyCollectionChangedEventArgs<Pair<Item, int>> _) => count.Value = current.Sum(x => x.Value);
    }
}