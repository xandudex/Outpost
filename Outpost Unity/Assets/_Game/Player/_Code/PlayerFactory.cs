using MessagePipe;
using MysteryFoxes.Outpost.Storages;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerFactory
    {
        readonly StorageFactory storageFactory;
        readonly IBufferedPublisher<Player> playerPublisher;
        readonly LifetimeScope scope;
        public PlayerFactory(LifetimeScope scope, StorageFactory storageFactory, IBufferedPublisher<Player> playerPublisher)
        {
            this.scope = scope;
            this.storageFactory = storageFactory;
            this.playerPublisher = playerPublisher;
        }

        public Player Create(PlayerConfig data)
        {
            StorageModel wallet = storageFactory.Create(data.WalletData);
            StorageModel hands = storageFactory.Create(data.HandsData);

            PlayerModel player = new PlayerModel(data, wallet, hands);

            Player playerObject = scope.CreateChild(x => x.RegisterInstance(player)).Container
                        .Instantiate(player.Data.Prefab)
                        .GetComponent<Player>();

            playerPublisher.Publish(playerObject);

            return playerObject;
        }
    }


}