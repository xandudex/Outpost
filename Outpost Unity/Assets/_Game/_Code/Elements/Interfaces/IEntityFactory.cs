namespace MysteryFoxes.Outpost
{
    internal interface IEntityFactory<T, K> where T : IEntityData where K : IEntity
    {
        K Create(T data);
    }
}

