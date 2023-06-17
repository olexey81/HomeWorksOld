namespace HW_4_Collections
{
    internal class Queue
    {
        private List _items;

        public int Count => _items.Count;

        public Queue()
        {
            _items = new List(0);
        }
        public Queue(int capacity)
        {
            _items = new List(capacity);
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
    }
}

// Черга
// Принцип FIFO.



// Методи
//  Enqueue(object)         +
//  object Dequeue()        +
//  Clear()                 +
//  bool Contains(object)   +
//  object Peek()           + 
//  ToArray().              +

//  Свойство Count.

