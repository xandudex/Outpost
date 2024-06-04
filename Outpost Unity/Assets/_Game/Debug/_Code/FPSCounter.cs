using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public class FPSCounter : MonoBehaviour
    {
        private const string fpsVisualElementName = "fps";

        [SerializeField]
        UIDocument document;

        float everyTime = 0.3f;
        float time;
        Label label;

        private void Awake()
        {
            label = document.rootVisualElement.Q<Label>(fpsVisualElementName);
        }

        private void Update()
        {
            if (time < everyTime)
            {
                time += Time.deltaTime;
                return;
            }

            time = 0;

            label.text = (1 / Time.smoothDeltaTime).ToString("f0");
        }
    }
}
