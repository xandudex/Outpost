using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Items
{
    internal class ItemFactory
    {
        LifetimeScope scope;
        public ItemFactory(LifetimeScope scope)
        {
            this.scope = scope;
        }

        public Item Create(ItemSO itemData, int count = 1)
        {
            Item.Builder builder = new Item.Builder(itemData);
            return builder.Build();
        }

        public ItemObject CreateObject(Item item)
        {
            return scope.Container.CreateScope(x => x.RegisterInstance(item))
                            .Instantiate(item.Data.Prefab);
        }


    }
}