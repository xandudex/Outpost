using MessagePipe;
using MysteryFoxes.Outpost.Production;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Outpost.Services
{
    internal class ProductionService : IProductionService, IDisposable
    {
        List<Production.Production> productions = new();

        IDisposable disposable;

        readonly ProductionFactory factory;

        public ProductionService(ProductionFactory factory, ISubscriber<IEntity> entitySubscriber)
        {
            this.factory = factory;
            var bag = DisposableBag.CreateBuilder();

            entitySubscriber.Subscribe(x => ProductionCreated(x as Production.Production), x => x is Production.Production)
                            .AddTo(bag);

            disposable = bag.Build();
        }
        void ProductionCreated(Production.Production production)
        {
            Debug.Log(production.Data.name);
        }

        void IDisposable.Dispose()
        {
            disposable?.Dispose();
        }
    }
}
