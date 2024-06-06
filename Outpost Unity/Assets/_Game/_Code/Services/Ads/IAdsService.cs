using System;

namespace MysteryFoxes.Global.Services.Ads
{
    internal interface IAdsService
    {
        internal enum AdType { Interstitial, Rewarded }

        public event Action<AdData> ShowingAd;
        public event Action<AdData> ShowedAd;
    }
}
