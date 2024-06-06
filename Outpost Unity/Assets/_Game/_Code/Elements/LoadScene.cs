using MysteryFoxes.Global.Services;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Global
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField]
        int sceneId;

        ISceneLoader sceneLoader;
        [Inject]
        void Construct(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        private async void Start()
        {
            await Awaitable.WaitForSecondsAsync(1);
            await sceneLoader.LoadScene(sceneId);
        }

    }
}
