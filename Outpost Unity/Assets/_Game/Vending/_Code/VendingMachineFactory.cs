using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachineFactory
    {
        readonly LifetimeScope scope;
        readonly IPublisher<VendingMachine> vendingPublisher;

        public VendingMachineFactory(LifetimeScope scope, IPublisher<VendingMachine> vendingPublisher)
        {
            this.scope = scope;
            this.vendingPublisher = vendingPublisher;
        }

        public VendingMachine Create(VendingMachineConfig data, Transform parent, Vector3 pos, Quaternion rot)
        {
            VendingMachineModel vendingMachine = new VendingMachineModel(data);

            VendingMachine vendingMachineObject = scope.CreateChild(x => x.RegisterInstance(vendingMachine)).Container
                                                       .Instantiate(vendingMachine.Data.Prefab, pos, rot, parent)
                                                       .GetComponent<VendingMachine>();

            vendingPublisher.Publish(vendingMachineObject);

            return vendingMachineObject;
        }
    }
}
