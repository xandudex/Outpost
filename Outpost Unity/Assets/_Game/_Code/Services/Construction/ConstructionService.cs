using MessagePipe;
using MysteryFoxes.Outpost.Constructions;
using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Services
{
    internal class ConstructionService : IConstructionService, IInitializable, IDisposable
    {
        List<Construction> constructions = new();
        IDisposable disposable;

        private readonly ISubscriber<Construction> constructionSubscriber;

        public ConstructionService(ISubscriber<Construction> constructionSubscriber)
        {
            this.constructionSubscriber = constructionSubscriber;
        }

        public IReadOnlyList<Construction> Constructions => constructions;

        public void Initialize()
        {
            DisposableBagBuilder bag = DisposableBag.CreateBuilder();

            constructionSubscriber.Subscribe(x => constructions.Add(x), x => x is Construction)
                            .AddTo(bag);

            disposable = bag.Build();
        }

        public void Dispose()
        {
            disposable?.Dispose();
        }
    }
}
