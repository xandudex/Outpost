using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Production
{
    internal class ProductionFactory
    {
        readonly LifetimeScope scope;
        public ProductionFactory(LifetimeScope scope)
        {
            this.scope = scope;
        }

        public Production Create(ProductionSO productionData)
        {
            Production.Builder builder = new Production.Builder(productionData);
            return builder.Build();
        }

        public ProductionObject CreateObject(Production production)
        {
            return scope.CreateChild(x => x.RegisterInstance(production)).Container
                        .Instantiate(production.Data.Prefab);
        }
    }
}
