namespace MysteryFoxes.Outpost.Vending
{
    internal partial class VendingMachine : IEntity
    {
        internal class Builder
        {
            VendingMachineSO data;
            public Builder(VendingMachineSO data)
            {
                this.data = data;
            }

            public VendingMachine Build()
            {
                VendingMachine vendingMachine = new VendingMachine(data);
                return vendingMachine;
            }
        }
    }
}
