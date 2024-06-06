using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MysteryFoxes.Global.Services
{
    internal class SceneLoader : ISceneLoader
    {
        ReactiveProperty<float> progress = new();

        public ReadOnlyReactiveProperty<float> Progress => progress;

        public async Awaitable LoadScene(int id) => await Load(id);

        async Awaitable Load(int id)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);
            asyncOperation.allowSceneActivation = false;
            progress.Value = 0;
            while (asyncOperation.progress < 0.9f)
            {
                progress.Value = asyncOperation.progress / 0.9f;
                await Awaitable.NextFrameAsync();

            }
            progress.Value = 1;

            await Awaitable.WaitForSecondsAsync(2);
            asyncOperation.allowSceneActivation = true;

        }

    }
}
