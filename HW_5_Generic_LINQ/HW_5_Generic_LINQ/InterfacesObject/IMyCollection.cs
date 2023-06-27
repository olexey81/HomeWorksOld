using System.Collections;

namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyCollection : IEnumerable
    {
        int Count { get; }
        object[] ToArray();
        void Clear();
    }
}
