using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Production
{
    internal class ProductionFactory
    {
        readonly Container container;

        public ProductionFactory(Container container)
        {
            this.container = container;
        }

        public Production Create(ProductionSO productionData)
        {
            Production.Builder builder = new Production.Builder(productionData);
            return builder.Build();
        }

        public ProductionObject CreateObject(Production production)
        {
            return container.CreateScope(Builder)
                            .Instantiate(production.Data.Prefab);

            void Builder(IContainerBuilder builder)
            {
                builder.RegisterInstance(production);
            }
        }
    }
}
