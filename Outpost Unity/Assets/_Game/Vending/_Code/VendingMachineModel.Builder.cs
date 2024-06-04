namespace MysteryFoxes.Outpost.Vending
{
    internal partial class VendingMachineModel : IEntity
    {
        internal class Builder
        {
            VendingMachineConfig data;
            public Builder(VendingMachineConfig data)
            {
                this.data = data;
            }

            public VendingMachineModel Build()
            {
                VendingMachineModel vendingMachine = new VendingMachineModel(data);
                return vendingMachine;
            }
        }
    }
}
