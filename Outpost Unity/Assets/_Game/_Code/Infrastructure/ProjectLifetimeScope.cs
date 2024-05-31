using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance("Hello world");
        }
    }
}
