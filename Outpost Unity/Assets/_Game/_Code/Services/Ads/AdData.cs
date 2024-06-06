
namespace MysteryFoxes.Global.Services.Ads
{
    internal class AdData
    {
        public AdData(AdType adType, string id, string network)
        {
            AdType = adType;
            Id = id;
            Network = network;
        }
        public AdType AdType { get; private set; }
        public string Id { get; private set; }
        public string Network { get; private set; }
    }
}
