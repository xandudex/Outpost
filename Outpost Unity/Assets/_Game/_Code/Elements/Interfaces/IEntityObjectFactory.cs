namespace MysteryFoxes.Outpost
{
    internal interface IEntityObjectFactory<T, K> where T : IEntity where K : IEntityObject
    {
        K Create(T entity);
    }
}

