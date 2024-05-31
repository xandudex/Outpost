namespace MysteryFoxes.Outpost.Items
{

    internal partial class Item
    {
        internal class Builder
        {
            ItemSO itemData;

            public Builder(ItemSO itemData)
            {
                this.itemData = itemData;
            }

            public Item Build() => new Item(itemData);
        }
    }
}
