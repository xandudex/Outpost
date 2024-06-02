using MysteryFoxes.Outpost.Items;
using R3;
using System.Linq;

namespace MysteryFoxes.Outpost
{
    internal class Upgrade<T>
    {
        T[] values;
        int currentIndex;
        Pair<ItemSO, int>[] cost;
        ReactiveProperty<T> value = new();

        public Upgrade(T[] values, Pair<ItemSO, int>[] cost, int initialIndex)
        {
            this.values = values;
            this.cost = cost;
            Set(initialIndex);
        }

        public T[] Values => values.ToArray();
        public int CurrentIndex => currentIndex;
        public Pair<ItemSO, int>[] Cost => cost.ToArray();
        public ReadOnlyReactiveProperty<T> Value => value;
        public int Count => values.Length;

        public void Increase()
        {
            if (currentIndex >= values.Length) return;

            currentIndex++;
            value.Value = values[currentIndex];
        }

        public void Set(int newIndex)
        {
            if (newIndex >= values.Length) { newIndex = values.Length; }

            currentIndex = newIndex;
            value.Value = values[currentIndex];
        }

        public static implicit operator T(Upgrade<T> upgrade) => upgrade.Value.CurrentValue;
    }
}
