using MysteryFoxes.Outpost.Services;
using MysteryFoxes.Systems.UI;
using Unity.Cinemachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class GameLifetimeScope : LifetimeScope
    {
        [TagField]
        [SerializeField]
        string autoInjectWithTag;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterEntities(builder);

            SetupAutoInjection();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PanelService>();
            builder.RegisterEntryPoint<ProductionService>();
            builder.RegisterEntryPoint<ConstructionService>();
        }

        private void RegisterEntities(IContainerBuilder builder)
        {

        }

        private void SetupAutoInjection()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(autoInjectWithTag);
            foreach (var item in gameObjects)
                autoInjectGameObjects.Add(item);
        }
    }
}
