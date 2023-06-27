using System.Collections;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesObject
{
    public interface IMyCollection : IEnumerable
    {
        int Count { get; }
        object[] ToArray();
        void Clear();
    }
}
