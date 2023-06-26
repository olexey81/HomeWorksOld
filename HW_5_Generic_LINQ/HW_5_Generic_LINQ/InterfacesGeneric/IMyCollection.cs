using System.Collections;

namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        T[] ToArray();
        void Clear();
        bool Contains(T value);
    }
}
