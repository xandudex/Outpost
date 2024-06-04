using MysteryFoxes.Outpost.Storages;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    internal class Player : MonoBehaviour, IConstructor
    {
        [SerializeField]
        Storage hands;

        PlayerModel model;

        [Inject]
        void Construct(PlayerModel model)
        {
            this.model = model;
        }

        public PlayerModel Model => model;

        IReadOnlyList<StorageModel> IConstructor.Storages => new List<StorageModel>() { model.Hands, model.Wallet };
    }
}