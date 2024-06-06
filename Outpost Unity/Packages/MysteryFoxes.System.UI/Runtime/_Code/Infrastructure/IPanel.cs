using System.Threading;
using UnityEngine;

namespace MysteryFoxes.Systems.UI
{
    public interface IPanel
    {
        PanelType PanelType { get; }
        bool IsVisible { get; internal set; }
        bool InFocus { get; internal set; }

        internal void Hide();

        internal Awaitable ShowAsync(CancellationToken cancellationToken = default);
        internal Awaitable HideAsync(CancellationToken cancellationToken = default);
    }
}
