using Game.Player;
using MysteryFoxes.Outpost.Items;
using MysteryFoxes.Outpost.Production;
using MysteryFoxes.Outpost.Services;
using MysteryFoxes.Outpost.Storages;
using MysteryFoxes.Outpost.Vending;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        Player playerPrefab;

        [SerializeField]
        Transform playerMarker;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFactories(builder);
            RegisterServices(builder);
            RegisterEntities(builder);
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<UpgradeFactory>(Lifetime.Singleton);
            builder.Register<ItemFactory>(Lifetime.Singleton);
            builder.Register<StorageFactory>(Lifetime.Singleton);
            builder.Register<ProductionFactory>(Lifetime.Singleton);
            builder.Register<VendingMachineFactory>(Lifetime.Singleton);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ProductionService>();
        }


        private void RegisterEntities(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(playerPrefab, Lifetime.Singleton)
                   .UnderTransform(playerMarker)
                   .AsSelf();
        }
    }
}
