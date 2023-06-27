namespace HomeWorks.HW_5_Generic_LINQ.InterfacesGeneric
{
    public interface IMyStack<T> : IMyCollection<T>
    {
        T Peek();
        void Push(T item);
        T Pop();
    }
}
