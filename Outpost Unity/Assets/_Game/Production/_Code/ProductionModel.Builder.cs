using MysteryFoxes.Outpost.Storages;
using System;

namespace MysteryFoxes.Outpost.Productions
{
    internal partial class ProductionModel
    {
        public class Builder
        {
            ProductionConfig productionData;
            StorageModel storage;
            Guid guid;

            public Builder(ProductionConfig productionData)
            {
                this.productionData = productionData;
                guid = Guid.NewGuid();
            }
            public Builder WithGuid(Guid guid)
            {
                this.guid = guid;
                return this;
            }

            public Builder WithStorage(StorageModel storage)
            {
                this.storage = storage;
                return this;
            }

            public ProductionModel Build()
            {
                return new ProductionModel(productionData, guid, storage);
            }
        }
    }
}
