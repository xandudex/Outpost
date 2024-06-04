using MessagePipe;
using MysteryFoxes.Outpost.Storages;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerFactory : IEntityFactory<PlayerSO, Player>, IEntityObjectFactory<Player, PlayerObject>
    {
        readonly StorageFactory storageFactory;
        readonly IBufferedPublisher<IEntity> entityPublisher;
        readonly IBufferedPublisher<IEntityObject> entityObjectPublisher;
        readonly LifetimeScope scope;
        public PlayerFactory(LifetimeScope scope, StorageFactory storageFactory, IBufferedPublisher<IEntity> entityPublisher, IBufferedPublisher<IEntityObject> entityObjectPublisher)
        {
            this.scope = scope;
            this.storageFactory = storageFactory;
            this.entityPublisher = entityPublisher;
            this.entityObjectPublisher = entityObjectPublisher;
        }

        public Player Create(PlayerSO data)
        {
            Storage wallet = storageFactory.Create(data.WalletData);
            Storage hands = storageFactory.Create(data.HandsData);
            Player player = new Player(data, wallet, hands);

            entityPublisher.Publish(player);

            return player;
        }

        public PlayerObject Create(Player player)
        {
            PlayerObject playerObject = scope.CreateChild(x => x.RegisterInstance(player)).Container
                        .Instantiate(player.Data.Prefab)
                        .GetComponent<PlayerObject>();

            entityObjectPublisher.Publish(playerObject);

            return playerObject;
        }
    }


}