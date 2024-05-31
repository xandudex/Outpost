using MysteryFoxes.Outpost.Production;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Services
{
    internal class ProductionService : IProductionService, IInitializable
    {
        List<Production.Production> productions = new();

        readonly ProductionFactory factory;

        public ProductionService(ProductionFactory factory)
        {
            this.factory = factory;
        }

        public void Initialize()
        {

            ProductionMarker[] productionMarkers = Resources.FindObjectsOfTypeAll<ProductionMarker>();
            for (int i = 0; i < productionMarkers.Length; i++)
            {
                ProductionMarker marker = productionMarkers[i];
                Production.Production production = factory.Create(marker.Production);
                productions.Add(production);

                ProductionObject productionObject = factory.CreateObject(production);

                productionObject.transform.SetParent(marker.transform.parent);
                productionObject.transform.SetPositionAndRotation(marker.transform.position, marker.transform.rotation);
            }
        }
    }
}
