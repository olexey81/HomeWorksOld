using static HW_5_Generic_LINQ.Collections.MyBinarySearchTree;

namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyBinarySearchTree<T> : IMyCollection<T>
    {
        void Add(T value);
    }
}
