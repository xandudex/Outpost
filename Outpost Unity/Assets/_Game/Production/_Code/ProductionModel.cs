using MysteryFoxes.Outpost.Storages;
using System;

namespace MysteryFoxes.Outpost.Productions
{
    internal partial class ProductionModel
    {
        public readonly StorageModel Storage;
        public readonly ProductionConfig Data;
        public readonly Guid Guid;

        private ProductionModel(ProductionConfig data, Guid guid, StorageModel storage)
        {
            Data = data;
            Guid = guid;
            Storage = storage;
        }
    }
}
