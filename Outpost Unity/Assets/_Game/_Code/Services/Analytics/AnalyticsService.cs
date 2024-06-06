using Game.Services.Analytics.Providers;
using System.Collections.Generic;
using VContainer.Unity;

namespace MysteryFoxes.Global.Services.Analytics
{
    internal class AnalyticsService : IAnalyticsService
    {
        List<IAnalyticsProvider> analyticsProviders;
        private readonly LifetimeScope scope;

        public AnalyticsService(LifetimeScope scope)
        {
            this.scope = scope;

            RegisterProviders();
        }

        private void RegisterProviders()
        {
            analyticsProviders = new();
            //todo:register analytics providers
        }

        public void Register(string name, params (string name, object obj)[] parameters)
        => analyticsProviders.ForEach(x => x.Register(name, parameters));
    }
}
