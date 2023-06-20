namespace HW_4_Collections
{
    class Stack
    {
        private List _items;
        public int Count => _items.Count;

        public Stack()
        {
            _items = new List(0);
        }
        public Stack(int capacity)
        {
            _items = new List(capacity);
        }
        public void Push(object item) => _items.Add(item);
        public object Pop()
        {
            if (Count > 0)
            {
                object dequeue = _items[Count - 1];
                _items.RemoveAt(Count - 1);
                return dequeue;
            }
            else
                return null;
        }
        public object Peek()
        {
            if (Count > 0)
                return _items[Count - 1];
            else
                return null;
        }
        public void Clear() => _items.Clear();
        public bool Contains(object item) => _items.Contains(item);
        public object[] ToArray() => _items.ToArray();
    }
}


//      Стек
//      Принцип LIFO.

//      методи:

//      Push(object)            +
//      object Pop()            +
//      object Peek()           +
//      Clear()                 +
//      bool Contains(object)   +
//      ToArray()               +

//      Свойство Count.         +

