using MysteryFoxes.Outpost.Player;
using MysteryFoxes.Outpost.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MysteryFoxes.Outpost
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        PlayerSO playerData;

        [SerializeField]
        Transform playerMarker;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterEntities(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ProductionService>();
        }

        private void RegisterEntities(IContainerBuilder builder)
        {
            CreateAndRegisterPlayer(builder);
        }

        private void CreateAndRegisterPlayer(IContainerBuilder builder)
        {
            PlayerFactory playerFactory = Parent.Container.Resolve<PlayerFactory>();
            Player.Player player = playerFactory.Create(playerData);
            PlayerObject playerObject = playerFactory.CreateObject(player);

            playerObject.transform.SetParent(playerMarker.parent);
            playerObject.transform.SetPositionAndRotation(playerMarker.position, playerMarker.rotation);

            builder.RegisterInstance(player);
            builder.RegisterInstance(playerObject);
        }
    }
}
