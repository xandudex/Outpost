using MysteryFoxes.Outpost.Storages;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerObject : MonoBehaviour, IEntityObject, IConstructor
    {
        [SerializeField]
        StorageObject hands;

        Player model;

        [Inject]
        void Construct(Player model)
        {
            this.model = model;
        }

        public Player Data => model;

    }
}