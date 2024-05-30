using MysteryFoxes.Outpost.Items;
using MysteryFoxes.Outpost.Production;
using MysteryFoxes.Outpost.Storages;
using MysteryFoxes.Outpost.Vending;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterFactories(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UpgradeFactory>();
            builder.RegisterEntryPoint<ItemFactory>();
            builder.RegisterEntryPoint<StorageFactory>();
            builder.RegisterEntryPoint<ProductionFactory>();
            builder.RegisterEntryPoint<VendingMachineFactory>();
        }
    }
}
