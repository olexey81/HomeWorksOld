using HW_5_Generic_LINQ.Interfaces;
using System.Collections;

namespace HW_5_Generic_LINQ.Collections
{
    internal class MyQueue<T> : IMyQueue<T>
    {
        protected MyList<T> _items;

        public int Count => _items.Count;

        public MyQueue()
        {
            _items = new MyList<T>();
        }
        public MyQueue(int capacity)
        {
            _items = new MyList<T>(capacity);
        }

        public virtual void Enqueue(T item) => _items.Add(item);
        public T Dequeue()
        {
            if (Count > 0)
            {
                T dequeue = _items[0];
                _items.RemoveAt(0);
                return dequeue;
            }
            throw new InvalidOperationException();
        }
        public void Clear() => _items.Clear();
        public bool Contains(T item) => _items.Contains(item);
        public T Peek()
        {
            if (Count > 0)
                return _items[0];
            else
                throw new InvalidOperationException();
        }
        public T[] ToArray() => _items.ToArray();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public  IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator<T> GetEnumerator() => new QueueIterator<T>(_items);
        private class QueueIterator<T> : IEnumerator<T>
        {
            private readonly MyList<T> _items;
            private int _index;
            public T Current { get; private set; }
            object IEnumerator.Current => Current;

            public QueueIterator(MyList<T> items)
            {
                _items = items;
                _index = 0;
            }
            public bool MoveNext()
            {
                if (_index < _items.Count)
                {
                    Current = _items[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
            }

            public void Dispose()
            {
            }
        }

    }
}

