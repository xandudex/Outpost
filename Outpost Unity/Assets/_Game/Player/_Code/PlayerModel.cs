using MysteryFoxes.Outpost.Storages;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerModel
    {
        readonly PlayerConfig data;
        private readonly StorageModel wallet;
        private readonly StorageModel hands;

        public PlayerModel(PlayerConfig data, StorageModel wallet, StorageModel hands)
        {
            this.data = data;
            this.wallet = wallet;
            this.hands = hands;
        }

        public PlayerConfig Data => data;
        public StorageModel Wallet => wallet;
        public StorageModel Hands => hands;
    }
}