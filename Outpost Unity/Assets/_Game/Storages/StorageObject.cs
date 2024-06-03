using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Storages
{
    internal class StorageObject : MonoBehaviour, IEntityObject
    {
        Storage storage;

        [Inject]
        void Construct(Storage storage)
        {
            this.storage = storage;
        }

        public Storage Storage => storage;
    }
}