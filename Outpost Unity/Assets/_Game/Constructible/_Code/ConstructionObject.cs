using ObservableCollections;
using R3;
using System;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Constructions
{

    [RequireComponent(typeof(Zone))]
    internal class ConstructionObject : MonoBehaviour
    {
        [SerializeField]
        ConstructionSO data;

        [SerializeField]
        UniqueID uniqueID;

        Zone zone;

        ObservableList<IConstructor> constructors = new();

        Construction construction;
        [Inject]
        void Construct(Construction construction)
        {
            this.construction = construction;

            Debug.Log(construction.Guid);

            zone = GetComponent<Zone>();

            zone.DetectedInCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Add(x)).AddTo(this);

            zone.DetectedOutCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Remove(x)).AddTo(this);
        }

        public ConstructionSO Data => data;
        public Guid Guid => uniqueID.Id;


    }
}
