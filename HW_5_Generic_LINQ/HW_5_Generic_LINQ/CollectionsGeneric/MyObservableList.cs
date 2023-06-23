
namespace HW_5_Generic_LINQ.Collections
{
    internal class MyObservableList<T> : MyList<T>
    {
        public event Action<T> ItemAdded;
        public event Action<T> ItemRemoved;

        public override void Add(T item)
        {
            base.Add(item);
            ItemAdded?.Invoke(item);
        }

        public override bool Remove(T item)
        {
            bool result = base.Remove(item);
            if (result)
                ItemRemoved?.Invoke(item);
            return result;
        }
    }
}
