namespace MysteryFoxes.Outpost.Items
{
    internal partial class Item : IEntity
    {
        ItemSO data;
        private Item(ItemSO data)
        {
            this.data = data;
        }

        public ItemSO Data => data;
    }
}

