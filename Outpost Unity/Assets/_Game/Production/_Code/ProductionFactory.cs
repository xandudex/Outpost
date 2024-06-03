using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Production
{
    internal class ProductionFactory : IEntityFactory<ProductionSO, Production>, IEntityObjectFactory<Production, ProductionObject>
    {
        readonly LifetimeScope scope;
        readonly IPublisher<IEntity> entityPublisher;
        readonly IPublisher<IEntityObject> entityObjectPublisher;

        public ProductionFactory(LifetimeScope scope, IPublisher<IEntity> entityPublisher, IPublisher<IEntityObject> entityObjectPublisher)
        {
            this.scope = scope;
            this.entityPublisher = entityPublisher;
            this.entityObjectPublisher = entityObjectPublisher;
        }

        public Production Create(ProductionSO productionData)
        {
            Production.Builder builder = new Production.Builder(productionData);
            Production production = builder.Build();

            entityPublisher.Publish(production);

            return production;
        }

        public ProductionObject Create(Production production)
        {
            ProductionObject productionObject = scope.CreateChild(x => x.RegisterInstance(production)).Container
                        .Instantiate(production.Data.Prefab)
                        .GetComponent<ProductionObject>();

            entityObjectPublisher.Publish(productionObject);

            return productionObject;
        }
    }
}
