using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Items
{
    internal class ItemFactory : IEntityFactory<ItemSO, Item>, IEntityObjectFactory<Item, ItemObject>
    {
        LifetimeScope scope;
        readonly IPublisher<IEntity> entityPublisher;
        readonly IPublisher<IEntityObject> entityObjectPublisher;

        public ItemFactory(LifetimeScope scope, IPublisher<IEntity> entityPublisher, IPublisher<IEntityObject> entityObjectPublisher)
        {
            this.scope = scope;
            this.entityPublisher = entityPublisher;
            this.entityObjectPublisher = entityObjectPublisher;
        }

        public Item Create(ItemSO itemData)
        {
            Item.Builder builder = new Item.Builder(itemData);
            Item item = builder.Build();

            entityPublisher.Publish(item);

            return item;
        }

        public ItemObject Create(Item item)
        {
            ItemObject itemObject = scope.CreateChild(x => x.RegisterInstance(item)).Container
                        .Instantiate(item.Data.Prefab)
                        .GetComponent<ItemObject>();

            entityObjectPublisher.Publish(itemObject);

            return itemObject;
        }
    }
}