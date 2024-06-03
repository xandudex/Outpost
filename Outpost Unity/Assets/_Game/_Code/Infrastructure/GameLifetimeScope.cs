using MysteryFoxes.Outpost.Services;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class GameLifetimeScope : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterEntities(builder);
        }

        private void RegisterEntities(IContainerBuilder builder)
        {
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ProductionService>();
            builder.RegisterEntryPoint<ConstructionService>();
        }


    }
}
