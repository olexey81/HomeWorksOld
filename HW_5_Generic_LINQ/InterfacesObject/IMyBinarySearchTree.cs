using static HomeWorks.HW_5_Generic_LINQ.CollectionsObject.MyBinarySearchTree;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesObject
{
    public interface IMyBinarySearchTree : IMyCollection
    {
        Node Root { get; }
        void Add(int value);
        bool Contains(int value);
    }
}
