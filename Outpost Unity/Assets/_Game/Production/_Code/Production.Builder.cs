using MysteryFoxes.Outpost.Storages;

namespace MysteryFoxes.Outpost.Production
{
    internal partial class Production
    {
        public class Builder
        {
            ProductionSO productionData;
            Storage storage;

            public Builder(ProductionSO productionData)
            {
                this.productionData = productionData;
            }

            public Builder WithStorage(Storage storage)
            {
                this.storage = storage;
                return this;
            }

            public Production Build()
            {
                return new Production(productionData, storage);
            }
        }
    }
}
