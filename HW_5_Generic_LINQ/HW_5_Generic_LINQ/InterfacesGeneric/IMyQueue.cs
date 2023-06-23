namespace HW_5_Generic_LINQ.Interfaces
{
    internal interface IMyQueue<T> : IMyCollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        bool Contains(T item);

    }
}
