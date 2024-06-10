using System;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Systems.UI
{
    [CreateAssetMenu(fileName = "PanelSettings", menuName = "MysteryFoxes/Settings/PanelSettings")]
    public class PanelSettings : ScriptableObject
    {
        [SerializeField]
        List<PanelData> data;

        public IReadOnlyList<PanelData> Data => data;

        [Serializable]
        public class PanelData
        {
            [SerializeField]
            PanelBase panelPrefab;

            [SerializeField]
            bool newInstanceEveryTime;

            public PanelBase PanelPrefab => panelPrefab;
            public bool NewInstanceEveryTime => newInstanceEveryTime;
        }
    }
}
