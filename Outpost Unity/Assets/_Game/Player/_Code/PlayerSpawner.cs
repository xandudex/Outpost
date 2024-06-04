using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        Transform playerMarker;

        [SerializeField]
        PlayerConfig playerData;

        PlayerFactory playerFactory;

        [Inject]
        void Construct(PlayerFactory playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        private void Start()
        {
            Player playerObject = playerFactory.Create(playerData);

            playerObject.transform.SetParent(playerMarker.parent);
            playerObject.transform.SetPositionAndRotation(playerMarker.position, playerMarker.rotation);
        }
    }
}
