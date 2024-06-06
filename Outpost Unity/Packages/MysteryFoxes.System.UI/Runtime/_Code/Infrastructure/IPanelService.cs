using ObservableCollections;
using R3;

namespace MysteryFoxes.Systems.UI
{

    public interface IPanelService
    {
        ReadOnlyReactiveProperty<IPanel> CurrentMain { get; }
        IObservableCollection<IPanel> CurrentAdditiveStack { get; }

        void Show(ICommonPanel panel, IPanel afterPanel = null);
        void Show<K>(IPayloadedPanel<K> panel, K payload, IPanel afterPanel = null);

        void Hide(IPanel panel = null);
        void HideAll();
    }
}
