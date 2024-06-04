using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Productions
{
    internal class ProductionFactory
    {
        readonly LifetimeScope scope;
        readonly IPublisher<Production> productionPublisher;

        public ProductionFactory(LifetimeScope scope, IPublisher<Production> productionPublisher)
        {
            this.scope = scope;
            this.productionPublisher = productionPublisher;
        }

        public Production Create(ProductionConfig productionData, Transform parent, Vector3 pos, Quaternion rot)
        {
            ProductionModel production = new ProductionModel.Builder(productionData).Build();

            Production productionObject = scope.CreateChild(x => x.RegisterInstance(production)).Container
                        .Instantiate(production.Data.Prefab, pos, rot, parent)
                        .GetComponent<Production>();

            productionPublisher.Publish(productionObject);

            return productionObject;
        }
    }
}
