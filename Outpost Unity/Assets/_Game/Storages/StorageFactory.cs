using MessagePipe;

namespace MysteryFoxes.Outpost.Storages
{
    internal class StorageFactory : IEntityFactory<StorageData, Storage>
    {
        readonly UpgradeFactory upgradeFactory;
        readonly IPublisher<IEntity> entityPublisher;

        public StorageFactory(UpgradeFactory upgradeFactory, IPublisher<IEntity> entityPublisher)
        {
            this.upgradeFactory = upgradeFactory;
            this.entityPublisher = entityPublisher;
        }

        public Storage Create(StorageData data)
        {
            Storage storage = new Storage(data, data.Storable, upgradeFactory.Create(data.Capacity));

            entityPublisher.Publish(storage);

            return storage;
        }
    }
}