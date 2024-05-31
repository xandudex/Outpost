using MysteryFoxes.Outpost.Interactable;
using MysteryFoxes.Outpost.Storages;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerObject : MonoBehaviour, IConstructor
    {
        [SerializeField]
        StorageObject hands;

        Player data;

        [Inject]
        void Construct(Player data)
        {
            this.data = data;
        }

        public Player Data => data;

    }
}