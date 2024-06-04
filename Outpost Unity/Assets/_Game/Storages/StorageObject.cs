using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Storages
{
    internal class Storage : MonoBehaviour, IEntityObject
    {
        StorageModel model;

        [Inject]
        void Construct(StorageModel model)
        {
            this.model = model;
        }

        public StorageModel Model => model;
    }
}