using ObservableCollections;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryFoxes.Systems.UI
{
    public class PanelService : IPanelService
    {
        ObservableList<IPanel> currentShowingStack = new();

        List<IPanel> stack = new();

        public PanelService(PanelSettings panelSettings)
        {
            SetupPanels(panelSettings);
        }

        public IObservableCollection<IPanel> CurrentAdditiveStack => currentShowingStack;

        private void SetupPanels(PanelSettings panelSettings)
        {
            foreach (var item in panelSettings.Data)
            {
                if (item.NewInstanceEveryTime) continue;

                PanelBase instance = GameObject.Instantiate(item.PanelPrefab);
                stack.Add(instance);
            }
        }
        public void Open(string id) { }
        public void Open<T>(string id, T payload) { }
        public void Open(ICommonPanel panel, IPanel afterPanel = null)
        {
            AddToStack(panel, afterPanel);
            panel.Open();
        }

        public void Open<K>(IPayloadedPanel<K> panel, K payload, IPanel afterPanel = null)
        {
            AddToStack(panel, afterPanel);
            panel.Open(payload);
        }

        public void Close(IPanel panel)
        {
            if (!currentShowingStack.Contains(panel)) return;

            currentShowingStack.Remove(panel);

            panel.Close();
        }

        public void CloseAll()
        {
            currentShowingStack.ForEach(x => x.Close());
        }

        void AddToStack(IPanel panel, IPanel afterPanel = null)
        {
            if (afterPanel != null && currentShowingStack.Contains(afterPanel))
            {
                int index = currentShowingStack.IndexOf(afterPanel);
                currentShowingStack.Insert(index, panel);
            }
            else
                currentShowingStack.Add(panel);
        }
    }
}
