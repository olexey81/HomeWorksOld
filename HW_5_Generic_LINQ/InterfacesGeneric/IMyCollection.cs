using System.Collections;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesGeneric
{
    public interface IMyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        T[] ToArray();
        void Clear();
        bool Contains(T value);
    }
}
