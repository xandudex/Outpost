using MysteryFoxes.Outpost.Runner;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class RunnerLifetimeScope : LifetimeScope
    {
        [SerializeField]
        Vehicle vehicle;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(vehicle);
        }
    }
}
