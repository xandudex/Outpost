﻿namespace MysteryFoxes.Systems.UI
{
    public interface IPayloadedPanel<T> : IPanel
    {
        internal void Open(T payload);
    }
}