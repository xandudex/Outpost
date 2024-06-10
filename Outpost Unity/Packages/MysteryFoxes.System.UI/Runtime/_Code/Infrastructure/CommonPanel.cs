namespace MysteryFoxes.Systems.UI
{
    public abstract class CommonPanel : PanelBase, ICommonPanel
    {
        void ICommonPanel.Open()
        {
            gameObject.SetActive(true);
        }
    }
}
