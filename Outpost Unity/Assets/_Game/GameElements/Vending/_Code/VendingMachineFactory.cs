using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachineFactory
    {
        readonly LifetimeScope scope;

        public VendingMachineFactory(LifetimeScope scope)
        {
            this.scope = scope;
        }

        public VendingMachine Create(VendingMachineSO data)
        {
            return new VendingMachine(data);
        }

        public VendingMachineObject CreateObject(VendingMachine vendingMachine)
        {
            return scope.CreateChild(x => x.RegisterInstance(vendingMachine)).Container
                        .Instantiate(vendingMachine.Data.Prefab)
                        .GetComponent<VendingMachineObject>();
        }
    }
}
