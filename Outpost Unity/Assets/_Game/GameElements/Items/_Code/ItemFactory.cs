using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Items
{
    internal class ItemFactory
    {
        Container container;
        public ItemFactory(Container container)
        {
            this.container = container;
        }

        public Item Create(ItemSO itemData, int count = 1)
        {
            Item.Builder builder = new Item.Builder(itemData);
            return builder.Build();
        }

        public ItemObject CreateObject(Item item)
        {
            return container.CreateScope(Builder)
                            .Instantiate(item.Data.Prefab);

            void Builder(IContainerBuilder builder)
            {
                builder.RegisterInstance(item);
            }
        }


    }
}