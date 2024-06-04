using MessagePipe;

namespace MysteryFoxes.Outpost.Storages
{
    internal class StorageFactory : IEntityFactory<StorageData, StorageModel>
    {
        readonly UpgradeFactory upgradeFactory;
        readonly IPublisher<IEntity> entityPublisher;

        public StorageFactory(UpgradeFactory upgradeFactory, IPublisher<IEntity> entityPublisher)
        {
            this.upgradeFactory = upgradeFactory;
            this.entityPublisher = entityPublisher;
        }

        public StorageModel Create(StorageData data)
        {
            StorageModel storage = new StorageModel(data, data.Storable, upgradeFactory.Create(data.Capacity));

            entityPublisher.Publish(storage);

            return storage;
        }
    }
}