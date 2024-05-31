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

        public Item Create(ItemSO itemData)
        {
            Item.Builder builder = new Item.Builder(itemData);
            return builder.Build();
        }

        public ItemObject CreateObject(Item item)
        {
            return scope.CreateChild(x => x.RegisterInstance(item)).Container
                        .Instantiate(item.Data.Prefab)
                        .GetComponent<ItemObject>();
        }
    }
}