using MessagePipe;
using MysteryFoxes.Outpost.Constructions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace MysteryFoxes.Outpost.Services
{
    internal class ConstructionService : IConstructionService, IInitializable, IDisposable
    {
        private const string constructionTag = "Construction";

        List<Construction> constructions = new();
        IDisposable disposable;

        private readonly ISubscriber<IEntity> entitySubscriber;
        private readonly ConstructionFactory constructionFactory;

        public ConstructionService(ISubscriber<IEntity> entitySubscriber, ConstructionFactory constructionFactory)
        {
            this.entitySubscriber = entitySubscriber;
            this.constructionFactory = constructionFactory;
        }

        public IReadOnlyList<Construction> Constructions => constructions;

        public void Initialize()
        {
            DisposableBagBuilder bag = DisposableBag.CreateBuilder();

            entitySubscriber.Subscribe(x => constructions.Add(x as Construction), x => x is Construction)
                            .AddTo(bag);

            CreateConstructionEntities();

            disposable = bag.Build();
        }

        private void CreateConstructionEntities()
        {
            List<ConstructionObject> cObjects = GameObject.FindGameObjectsWithTag(constructionTag)
                                                          .Select(x => x.GetComponent<ConstructionObject>())
                                                          .ToList();

            foreach (var item in cObjects)
                constructionFactory.Create(item);
        }

        public void Dispose()
        {
            disposable?.Dispose();
        }
    }
}
