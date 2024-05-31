using MysteryFoxes.Outpost.Items;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Storages
{
    internal class StorageFactory
    {
        readonly UpgradeFactory upgradeFactory;
        readonly LifetimeScope scope;
        public StorageFactory(LifetimeScope scope, UpgradeFactory upgradeFactory)
        {
            this.scope = scope;
            this.upgradeFactory = upgradeFactory;
        }

        public Storage Create(StorageData data, Pair<Item, int>[] initial = null)
        {
            return new Storage(data.Storable, upgradeFactory.Create(data.Capacity), initial);
        }

        public StorageObject CreateObject(Storage storage, StorageObject prefab)
        {
            return scope.Container.CreateScope(x => x.RegisterInstance(storage))
                            .Instantiate(prefab);
        }
    }
}