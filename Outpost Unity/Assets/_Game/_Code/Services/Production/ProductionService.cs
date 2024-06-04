using MessagePipe;
using MysteryFoxes.Outpost.Productions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Services
{
    internal class ProductionService : IProductionService, IDisposable
    {
        List<Productions.ProductionModel> productions = new();

        IDisposable disposable;

        readonly ProductionFactory factory;

        public ProductionService(ProductionFactory factory, ISubscriber<IEntity> entitySubscriber)
        {
            this.factory = factory;
            var bag = DisposableBag.CreateBuilder();

            entitySubscriber.Subscribe(x => ProductionCreated(x as Productions.ProductionModel), x => x is Productions.ProductionModel)
                            .AddTo(bag);

            disposable = bag.Build();
        }
        void ProductionCreated(Productions.ProductionModel production)
        {
            Debug.Log(production.Data.name);
        }

        void IDisposable.Dispose()
        {
            disposable?.Dispose();
        }
    }
}
