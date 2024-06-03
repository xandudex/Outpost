using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        Transform playerMarker;

        [SerializeField]
        PlayerSO playerData;

        PlayerFactory playerFactory;
        [Inject]
        void Construct(PlayerFactory playerFactory)
        {
            this.playerFactory = playerFactory;

            Spawn();
        }

        private void Spawn()
        {
            Player player = playerFactory.Create(playerData);
            PlayerObject playerObject = playerFactory.Create(player);

            playerObject.transform.SetParent(playerMarker.parent);
            playerObject.transform.SetPositionAndRotation(playerMarker.position, playerMarker.rotation);
        }
    }
}
