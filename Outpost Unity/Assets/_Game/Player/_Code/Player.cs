using MysteryFoxes.Outpost.Storages;

namespace MysteryFoxes.Outpost.Player
{
    internal class Player : IEntity
    {
        readonly PlayerSO data;

        public Player(PlayerSO data, Storage wallet, Storage hands)
        {
            this.data = data;
        }

        public PlayerSO Data => data;
    }
}