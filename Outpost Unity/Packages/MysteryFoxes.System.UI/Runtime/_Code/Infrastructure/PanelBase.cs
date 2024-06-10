using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MysteryFoxes.Systems.UI
{
    [Serializable]
    public abstract class PanelBase : MonoBehaviour, IPanel
    {
        [SerializeField]
        PanelType panelType;

        [SerializeField, ReadOnly]
        bool isVisible;

        public PanelType PanelType => panelType;
        public bool IsVisible => isVisible;

        void IPanel.Close()
        {
            gameObject.SetActive(false);
            isVisible = false;
        }
    }
}
