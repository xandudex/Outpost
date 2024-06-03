using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Constructions
{
    internal class ConstructionFactory
    {
        private readonly LifetimeScope lifetimeScope;
        private readonly IPublisher<IEntity> entityPublisher;

        public ConstructionFactory(LifetimeScope lifetimeScope, IPublisher<IEntity> entityPublisher)
        {
            this.lifetimeScope = lifetimeScope;
            this.entityPublisher = entityPublisher;
        }

        public Construction Create(ConstructionObject constructionObject)
        {
            Construction construction = new Construction(constructionObject.Guid, constructionObject.Data);

            lifetimeScope.CreateChild(x => x.RegisterInstance(construction)).Container
                         .InjectGameObject(constructionObject.gameObject);

            entityPublisher.Publish(construction);

            return construction;
        }
    }
}
