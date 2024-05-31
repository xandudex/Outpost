using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachineObject : MonoBehaviour
    {
        VendingMachine vendingMachine;
        [Inject]
        void Construct(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }
        public VendingMachine VendingMachine => vendingMachine;
    }
}
