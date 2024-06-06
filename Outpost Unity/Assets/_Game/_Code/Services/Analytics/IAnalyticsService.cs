namespace MysteryFoxes.Global.Services.Analytics
{
    internal interface IAnalyticsService
    {
        public void Register(string name, params (string name, object obj)[] parameters);
    }
}
