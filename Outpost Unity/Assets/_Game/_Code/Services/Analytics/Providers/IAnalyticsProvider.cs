namespace Game.Services.Analytics.Providers
{
    internal interface IAnalyticsProvider
    {
        void Register(string name, params (string name, object obj)[] parameters);
    }
}
