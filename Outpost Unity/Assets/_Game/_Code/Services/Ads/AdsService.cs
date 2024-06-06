using System;

namespace MysteryFoxes.Global.Services.Ads
{
    internal class AdsService : IAdsService
    {
        public event Action<AdData> ShowingAd;
        public event Action<AdData> ShowedAd;
    }
}
