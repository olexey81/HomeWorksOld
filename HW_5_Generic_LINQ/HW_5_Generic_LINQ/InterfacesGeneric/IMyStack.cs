namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyStack<T> : IMyCollection<T>
    {
        T Peek();
        void Push(T item);
        T Pop();
    }
}
