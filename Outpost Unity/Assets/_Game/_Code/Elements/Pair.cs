namespace MysteryFoxes.Outpost
{
    internal struct Pair<T, K>
    {
        public T Key;
        public K Value;

        public Pair(T key, K value)
        {
            Key = key;
            Value = value;
        }
    }
}
