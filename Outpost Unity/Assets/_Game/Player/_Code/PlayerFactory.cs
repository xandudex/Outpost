using MysteryFoxes.Outpost.Storages;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerFactory
    {
        readonly StorageFactory storageFactory;
        readonly LifetimeScope scope;
        public PlayerFactory(LifetimeScope scope, StorageFactory storageFactory)
        {
            this.scope = scope;
            this.storageFactory = storageFactory;
        }

        public Player Create(PlayerSO data)
        {
            Storage wallet = storageFactory.Create(data.WalletData);
            Storage hands = storageFactory.Create(data.HandsData);

            return new Player(data, wallet, hands);
        }

        public PlayerObject CreateObject(Player player)
        {
            return scope.CreateChild(x => x.RegisterInstance(player)).Container
                        .Instantiate(player.Data.Prefab)
                        .GetComponent<PlayerObject>();
        }
    }


}