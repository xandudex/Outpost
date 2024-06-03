using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField]
        UIDocument document;

        float everyTime = 0.3f;
        float time;
        Label label;

        private void Awake()
        {
            label = document.rootVisualElement.Q<Label>("fps");
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
