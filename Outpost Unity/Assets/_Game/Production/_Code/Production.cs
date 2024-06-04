using MysteryFoxes.Outpost.Storages;

namespace MysteryFoxes.Outpost.Production
{
    internal partial class Production : IEntity
    {
        Storage storage;

        ProductionSO data;
        private Production(ProductionSO data, Storage storage)
        {
            this.data = data;
        }

        public Storage Storage => storage;
        public ProductionSO Data => data;
    }
}
