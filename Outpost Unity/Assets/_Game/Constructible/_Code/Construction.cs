using MysteryFoxes.Outpost.Productions;
using MysteryFoxes.Outpost.Vending;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Constructions
{

    [RequireComponent(typeof(Zone))]
    internal class Construction : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        ConstructionConfig data;

        Zone zone;

        ObservableList<IConstructor> constructors = new();

        ConstructionModel model;
        ProductionFactory productionFactory;
        VendingMachineFactory vendingFactory;
        [Inject]
        void Construct(VendingMachineFactory vendingFactory, ProductionFactory productionFactory, ConstructionModel model)
        {
            this.vendingFactory = vendingFactory;
            this.productionFactory = productionFactory;
            this.model = model;
            data = model.Data;

            zone = GetComponent<Zone>();

            zone.DetectedInCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Add(x)).AddTo(this);

            zone.DetectedOutCommand
                .Where(x => x is IConstructor)
                .Select(x => x as IConstructor)
                .Subscribe(x => constructors.Remove(x)).AddTo(this);

            model.Done.Subscribe(Constructed).AddTo(this);
        }

        private void Constructed(bool state)
        {
            if (!state) return;

            switch (model.Data)
            {
                case ProductionConfig data:
                    Production production = productionFactory.Create(data, transform.parent, transform.position, transform.rotation);
                    break;
                case VendingMachineConfig data:
                    VendingMachine vending = vendingFactory.Create(data, transform.parent, transform.position, transform.rotation);
                    break;
            }

            Destroy(gameObject);
        }

        public ConstructionConfig Data => data;

        private void Update()
        {
            if (model.Done.CurrentValue || constructors.Count == 0)
                return;

            model.Add(model.AppliedItems.First().Key, 10);
        }
    }
}
