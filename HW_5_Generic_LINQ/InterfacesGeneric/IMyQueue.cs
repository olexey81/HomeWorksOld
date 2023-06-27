namespace HomeWorks.HW_5_Generic_LINQ.InterfacesGeneric
{
    public interface IMyQueue<T> : IMyCollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
