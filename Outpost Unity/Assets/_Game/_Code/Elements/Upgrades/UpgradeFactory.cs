namespace MysteryFoxes.Outpost
{
    internal class UpgradeFactory
    {
        public Upgrade<T> Create<T>(UpgradeData<T> data)
        {
            return new Upgrade<T>(data.Values, data.Cost, 0);
        }
    }
}
