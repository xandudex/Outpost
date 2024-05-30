using MysteryFoxes.Outpost.Items;

namespace MysteryFoxes.Outpost.Storages
{
    internal class StorageFactory
    {
        readonly UpgradeFactory upgradeFactory;
        public StorageFactory(UpgradeFactory upgradeFactory)
        {
            this.upgradeFactory = upgradeFactory;
        }

        public Storage Create(StorageData data, Pair<Item, int>[] initial = null)
        {
            return new Storage(data.Storable, upgradeFactory.Create(data.Capacity), initial);
        }
    }
}