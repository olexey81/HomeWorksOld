namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyQueue<T> : IMyCollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
