using UnityEngine;

namespace MysteryFoxes.Outpost.Vending
{
    [CreateAssetMenu(fileName = "Vending Machine", menuName = "Outpost/Data/Vending Machine")]

    internal class VendingMachineSO : ScriptableObject
    {
        [SerializeField]
        VendingMachineObject prefab;

        public VendingMachineObject Prefab => prefab;
    }
}
