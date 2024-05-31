using R3;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Interactable
{
    [RequireComponent(typeof(Zone))]
    internal class ConstructionZone : MonoBehaviour
    {
        [SerializeField]
        ConstructableSO constructable;

        [SerializeReference, ReadOnly]
        List<IConstructor> constructors = new();

        Zone zone;
        private void Awake()
        {
            zone = GetComponent<Zone>();
        }

        private void Start()
        {
            zone.DetectedInCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Add(x)).AddTo(this);

            zone.DetectedOutCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Remove(x)).AddTo(this);
        }
    }
}
