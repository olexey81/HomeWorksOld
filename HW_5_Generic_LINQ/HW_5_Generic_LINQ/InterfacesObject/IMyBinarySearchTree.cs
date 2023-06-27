

using static HW_5_Generic_LINQ.Collections.MyBinarySearchTree;

namespace HW_5_Generic_LINQ.Interfaces
{
    public interface IMyBinarySearchTree : IMyCollection
    {
        Node Root { get; }
        void Add(int value);
        bool Contains(int value);
    }
}
