using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachineFactory : IEntityFactory<VendingMachineSO, VendingMachine>, IEntityObjectFactory<VendingMachine, VendingMachineObject>
    {
        readonly LifetimeScope scope;
        readonly IPublisher<IEntity> entityPublisher;
        readonly IPublisher<IEntityObject> entityObjectPublisher;

        public VendingMachineFactory(LifetimeScope scope, IPublisher<IEntity> entityPublisher, IPublisher<IEntityObject> entityObjectPublisher)
        {
            this.scope = scope;
            this.entityPublisher = entityPublisher;
            this.entityObjectPublisher = entityObjectPublisher;
        }

        public VendingMachine Create(VendingMachineSO data)
        {
            VendingMachine vendingMachine = new VendingMachine(data);

            entityPublisher.Publish(vendingMachine);

            return vendingMachine;
        }

        public VendingMachineObject Create(VendingMachine vendingMachine)
        {
            VendingMachineObject vendingMachineObject = scope.CreateChild(x => x.RegisterInstance(vendingMachine)).Container
                        .Instantiate(vendingMachine.Data.Prefab)
                        .GetComponent<VendingMachineObject>();

            entityObjectPublisher.Publish(vendingMachineObject);

            return vendingMachineObject;
        }
    }
}
