using System.Collections;

namespace HomeWorks.HW_5_Generic_LINQ.ExtensionMethods
{
    public class BaseEnum<T> : IEnumerable<T>
    {
        private readonly Func<IEnumerator<T>> _creator;

        public BaseEnum(Func<IEnumerator<T>> creator)
        {
            _creator = creator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _creator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
