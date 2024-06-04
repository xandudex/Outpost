using MessagePipe;
using System;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Constructions
{
    internal class ConstructionFactory
    {
        private readonly LifetimeScope lifetimeScope;
        private readonly IPublisher<Construction> constructionPublisher;

        public ConstructionFactory(LifetimeScope lifetimeScope, IPublisher<Construction> constructionPublisher)
        {
            this.lifetimeScope = lifetimeScope;
            this.constructionPublisher = constructionPublisher;
        }

        public Construction Create(ConstructionConfig data, Guid guid)
        {
            ConstructionModel model = new ConstructionModel(guid, data);

            Construction construction = lifetimeScope.CreateChild(x => x.RegisterInstance(model)).Container
                                                     .Instantiate((data as IConstructionData).Prefab)
                                                     .GetComponent<Construction>();

            constructionPublisher.Publish(construction);

            return construction;
        }
    }
}
