using MysteryFoxes.Outpost.Items;
using MysteryFoxes.Outpost.Player;
using MysteryFoxes.Outpost.Production;
using MysteryFoxes.Outpost.Storages;
using MysteryFoxes.Outpost.Vending;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFactories(builder);
            RegisterServices(builder);
        }
        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<UpgradeFactory>(Lifetime.Singleton);
            builder.Register<ItemFactory>(Lifetime.Singleton);
            builder.Register<StorageFactory>(Lifetime.Singleton);
            builder.Register<ProductionFactory>(Lifetime.Singleton);
            builder.Register<VendingMachineFactory>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);
        }
        private void RegisterServices(IContainerBuilder builder)
        {
        }
    }
}
