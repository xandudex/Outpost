namespace MysteryFoxes.Outpost.Vending
{
    internal partial class VendingMachineModel
    {

        readonly VendingMachineConfig data;

        public VendingMachineModel(VendingMachineConfig data)
        {
            this.data = data;
        }
        public VendingMachineConfig Data => data;
    }
}
