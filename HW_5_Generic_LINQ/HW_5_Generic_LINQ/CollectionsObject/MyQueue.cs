using HW_5_Generic_LINQ.Interfaces;
using System.Collections;

namespace HW_5_Generic_LINQ.Collections
{
    internal class MyQueue : IMyQueue
    {
        private MyList _items;
        public int Count => _items.Count;

        public MyQueue()
        {
            _items = new MyList(0);
        }
        public MyQueue(int capacity)
        {
            _items = new MyList(capacity);
        }

        public void Enqueue(object item) => _items.Add(item);
        public object Dequeue()
        {
            if (Count > 0)
            {
                object dequeue = _items[0];
                _items.RemoveAt(0);
                return dequeue;
            }
            return null;
        }
        public void Clear() => _items.Clear();
        public bool Contains(object item) => _items.Contains(item);
        public object Peek()
        {
            if (Count > 0)
                return _items[0];
            else
                return null;
        }
        public object[] ToArray() => _items.ToArray();

        //public  IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator GetEnumerator() => new QueueIterator(_items);
        private class QueueIterator : IEnumerator
        {
            private readonly MyList _items;
            private int _index;
            public object? Current { get; private set; }

            public QueueIterator(MyList items)
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
        }
    }
}