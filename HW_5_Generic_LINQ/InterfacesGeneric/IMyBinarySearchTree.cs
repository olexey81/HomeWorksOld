using static HomeWorks.HW_5_Generic_LINQ.CollectionsObject.MyBinarySearchTree;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesGeneric
{
    public interface IMyBinarySearchTree<T> : IMyCollection<T>
    {
        void Add(T value);
    }
}
