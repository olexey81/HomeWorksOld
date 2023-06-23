using static HW_5_Generic_LINQ.Collections.MyBinarySearchTree;

namespace HW_5_Generic_LINQ.Interfaces
{
    internal interface IMyBinarySearchTree<T> : IMyCollection<T>
    {
        void Add(T value);
        bool Contains(T value);
    }
}
