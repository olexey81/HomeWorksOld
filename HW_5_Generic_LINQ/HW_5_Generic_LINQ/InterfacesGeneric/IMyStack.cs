namespace HW_5_Generic_LINQ.Interfaces
{
    internal interface IMyStack<T> : IMyCollection<T>
    {
        T Peek();
        void Push(T item);
        T Pop();
        bool Contains(T item);
    }
}
