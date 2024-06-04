using MessagePipe;
using MysteryFoxes.Outpost.Constructions;
using MysteryFoxes.Outpost.Items;
using MysteryFoxes.Outpost.Player;
using MysteryFoxes.Outpost.Productions;
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
            RegisterMessagePipe(builder);
            RegisterFactories(builder);
            RegisterServices(builder);
        }

        private void RegisterMessagePipe(IContainerBuilder builder)
        {
            MessagePipeOptions options = builder.RegisterMessagePipe(o =>
            {
                o.EnableCaptureStackTrace = true;
            });
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            builder.RegisterMessageBroker<Player.Player>(options);
            builder.RegisterMessageBroker<Production>(options);
            builder.RegisterMessageBroker<Construction>(options);
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UpgradeFactory>().AsSelf();
            builder.RegisterEntryPoint<ItemFactory>().AsSelf();
            builder.RegisterEntryPoint<StorageFactory>().AsSelf();
            builder.RegisterEntryPoint<ConstructionFactory>().AsSelf();
            builder.RegisterEntryPoint<ProductionFactory>().AsSelf();
            builder.RegisterEntryPoint<VendingMachineFactory>().AsSelf();
            builder.RegisterEntryPoint<PlayerFactory>().AsSelf();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
        }
    }
}
