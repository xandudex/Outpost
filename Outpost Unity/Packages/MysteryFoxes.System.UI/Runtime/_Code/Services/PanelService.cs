using ObservableCollections;
using R3;

namespace MysteryFoxes.Systems.UI
{
    public class PanelService : IPanelService
    {
        ReactiveProperty<IPanel> currentMain = new();
        ObservableList<IPanel> currentAdditiveStack = new();
        public PanelService()
        {

        }

        public ReadOnlyReactiveProperty<IPanel> CurrentMain => currentMain;

        public IObservableCollection<IPanel> CurrentAdditiveStack => currentAdditiveStack;

        public void Hide(IPanel panel = null)
        {
            if (!currentAdditiveStack.Contains(panel)) return;

            currentAdditiveStack.Remove(panel);

            panel.Hide();
        }

        public void HideAll()
        {
            currentAdditiveStack.ForEach(x => x.Hide());
        }

        public void Show(ICommonPanel panel, IPanel afterPanel = null)
        {
            AddToStack(panel, afterPanel);
            panel.Show();
        }

        public void Show<K>(IPayloadedPanel<K> panel, K payload, IPanel afterPanel = null)
        {
            AddToStack(panel, afterPanel);
            panel.Show(payload);
        }

        void AddToStack(IPanel panel, IPanel afterPanel = null)
        {
            if (afterPanel != null && currentAdditiveStack.Contains(afterPanel))
            {
                int index = currentAdditiveStack.IndexOf(afterPanel);
                currentAdditiveStack.Insert(index, panel);
            }
            else
                currentAdditiveStack.Add(panel);
        }
    }
}
