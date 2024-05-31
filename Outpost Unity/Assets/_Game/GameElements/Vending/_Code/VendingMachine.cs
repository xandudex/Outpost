namespace MysteryFoxes.Outpost.Vending
{
    internal partial class VendingMachine
    {

        readonly VendingMachineSO data;

        public VendingMachine(VendingMachineSO data)
        {
            this.data = data;
        }
        public VendingMachineSO Data => data;
    }
}
