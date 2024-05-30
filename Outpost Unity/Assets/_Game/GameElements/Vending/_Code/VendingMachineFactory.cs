using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachineFactory
    {
        readonly Container container;

        public VendingMachineFactory(Container container)
        {
            this.container = container;
        }

        public VendingMachine Create(VendingMachineSO data)
        {
            return new VendingMachine(data);
        }

        public VendingMachineObject CreateObject(VendingMachine vendingMachine)
        {
            return container.CreateScope(Builder)
                            .Instantiate(vendingMachine.Data.Prefab);

            void Builder(IContainerBuilder builder)
            {
                builder.RegisterInstance(vendingMachine);
            }
        }
    }
}
