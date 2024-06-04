using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingMachine : MonoBehaviour, IEntityObject
    {
        VendingMachineModel model;

        [Inject]
        void Construct(VendingMachineModel model)
        {
            this.model = model;
        }

        public VendingMachineModel Model => model;
    }
}
