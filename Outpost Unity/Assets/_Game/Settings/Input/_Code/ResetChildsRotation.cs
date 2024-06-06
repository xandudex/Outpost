using UnityEngine;

namespace Game.Settings.Input
{
    public class ResetChildsRotation : MonoBehaviour
    {
        void Update()
        {
            Transform transform1 = transform.GetChild(0);
            if (transform1 != null)
                transform1.localRotation = Quaternion.identity;
            Destroy(this);
        }
    }
}
